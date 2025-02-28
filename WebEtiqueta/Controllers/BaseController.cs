using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebEtiqueta.Helpers;

public class BaseController : Controller
{
    private readonly IConfiguration _configuration;

    public BaseController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var httpContext = context.HttpContext;
        var request     = httpContext.Request;
        var session     = httpContext.Session;

        // Verifica se o cookie "AuthToken" está presente na requisição
        if (request.Cookies.TryGetValue("AuthToken", out var token))
        {
            // Valida o token JWT
            if (Jwt.ValidarJwtToken(token, _configuration))
            {
                // Extrai os dados do token
                var dadosToken = Jwt.DadosToken(token);

                // Tenta obter o nome de usuário do token
                if (dadosToken.TryGetValue("UsuarioNome", out var usuarioToken) && dadosToken.TryGetValue("Matriz", out var matriz))
                {
                    // Obtém o nome de usuário armazenado na sessão
                    var usuarioSessao   = session.GetString("UsuarioNome");
                    var matrizSessao    = session.GetString("Matriz");
                    //Console.WriteLine($"Sessão-{usuarioSessao}");
                    //Console.WriteLine($"Token-{usuarioToken}");
                    // Se o usuário da sessão estiver vazio, define-o com o valor do token
                    if (string.IsNullOrEmpty(usuarioSessao))
                    {
                        session.SetString("UsuarioNome", usuarioToken);
                        session.SetString("Matriz", matriz);
                        return;
                    }

                    // Se o usuário da sessão corresponder ao do token, permite a execução da ação
                    if (usuarioToken == usuarioSessao)
                    {
                        return;
                    }
                }
            }
        }

        // Se a autenticação falhar, redireciona para a página de login
        context.Result = new RedirectToActionResult("Login", "Auth", null);
    }
}
