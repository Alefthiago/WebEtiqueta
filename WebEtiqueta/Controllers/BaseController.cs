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
        if (context.HttpContext.Request.Cookies.TryGetValue("AuthToken", out var token))
        {
            bool usuarioAutenticado = Jwt.ValidarJwtToken(token, _configuration);

            if (usuarioAutenticado)
            {
                var dadosToken = Jwt.DadosToken(token);

                if (dadosToken.TryGetValue("Usuario", out var usuarioToken))
                {
                    var usuarioSessao = context.HttpContext.Session.GetString("Usuario");

                    if (!string.IsNullOrEmpty(usuarioSessao) && usuarioToken == usuarioSessao)
                    {
                        context.HttpContext.Items["DadosToken"] = dadosToken;
                        return;
                    }
                }
            }
        }

        // Se não estiver autenticado, redireciona para a página de login
        context.Result = new RedirectToActionResult("Login", "Auth", null);
    }
}
