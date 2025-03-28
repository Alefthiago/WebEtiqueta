using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebEtiqueta.Helpers;
using WebEtiqueta.Services;
using WebEtiqueta.Models;

public class BaseController : Controller
{
    private readonly IConfiguration _configuration;

    public BaseController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var httpContext = context.HttpContext;
        var request     = httpContext.Request;
        var response    = httpContext.Response;
        var session     = httpContext.Session;

        // Verifica se o cookie "AuthToken" existe e se é válido
        if (!request.Cookies.TryGetValue("AuthToken", out var token) || !Jwt.ValidarJwtToken(token, _configuration))
        {
            RedirecionarParaLogin(context);
            return;
        }

        // Obtém os valores da sessão antes de qualquer processamento
        string? usuarioSessao = session.GetString("UsuarioLogin");
        string? empresaSessao = session.GetString("Empresa");
        string? niveisJson = session.GetString("NivelAcesso");

        // Se a sessão já contém os dados necessários, evita reprocessamento
        if (!string.IsNullOrEmpty(usuarioSessao) && !string.IsNullOrEmpty(empresaSessao) && !string.IsNullOrEmpty(niveisJson))
        {
            DefinirViewData(usuarioSessao, empresaSessao, niveisJson);
            await next();
            return;
        }

        // Extrai os dados do token JWT
        var dadosToken = Jwt.DadosToken(token);
        if (!dadosToken.TryGetValue("UsuarioLogin", out var usuarioToken) ||
            !dadosToken.TryGetValue("Empresa", out var empresaToken))
        {
            RedirecionarParaLogin(context);
            return;
        }

        // Caso a sessão não tenha os dados, faz a consulta no banco
        var usuarioService = context.HttpContext.RequestServices.GetRequiredService<UsuarioService>();
        var consultaNivelAcesso = await usuarioService.PegarNivelAcessoPorUsuario(usuarioToken, empresaToken);

        if (consultaNivelAcesso.Status && consultaNivelAcesso.Dados != null)
        {
            niveisJson = JsonSerializer.Serialize(consultaNivelAcesso.Dados);
            session.SetString("UsuarioLogin", usuarioToken);
            session.SetString("NivelAcesso", niveisJson);
            session.SetString("Empresa", empresaToken);
        }
        else
        {
            response.Cookies.Delete("AuthToken");
            session.Clear();
            RedirecionarParaLogin(context);
            return;
        }

        // Define os dados na ViewData e prossegue para a próxima etapa do pipeline
        DefinirViewData(usuarioToken, empresaToken, niveisJson);
        await next();
    }

    private void DefinirViewData(string usuario, string empresa, string niveisJson)
    {
        ViewBag.UsuarioLogin    = usuario;
        ViewBag.Empresa          = empresa;
        ViewBag.NivelAcesso     = !string.IsNullOrEmpty(niveisJson)
            ? JsonSerializer.Deserialize<NivelAcessoModel>(niveisJson)
            : new NivelAcessoModel();
        ViewBag.NivelAcessoSuporteId = int.Parse(_configuration.GetSection("Suporte:NivelAcessoId").Value);
    }

    private void RedirecionarParaLogin(ActionExecutingContext context)
    {
        context.Result = new RedirectToActionResult("Login", "Auth", null);
    }
}