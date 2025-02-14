using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebEtiqueta.Helpers;
using WebEtiqueta.Services;
using Microsoft.Extensions.Configuration;

public class BaseController : Controller
{
    private readonly IConfiguration _configuration;

    public BaseController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (Request.Cookies.TryGetValue("AuthToken", out var token))
        {
            bool usuarioAutenticado = Jwt.ValidarJwtToken(token, _configuration);
            var usuarioId = Jwt.DadosToken(token)["UsuarioId"];

            if (usuarioAutenticado && int.TryParse(usuarioId, out var usuarioIdInt) && usuarioIdInt == HttpContext.Session.GetInt32("UsuarioId").GetValueOrDefault())
            {
                Dictionary<string, string> dadosToken = Jwt.DadosToken(token);
                context.HttpContext.Items["DadosToken"] = dadosToken;
                return;
            }
        }

        // Se não estiver autenticado, redireciona para a página de login
        context.Result = new RedirectToActionResult("Login", "Auth", null);
    }
}
