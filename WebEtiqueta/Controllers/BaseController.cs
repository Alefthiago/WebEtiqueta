using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using WebEtiqueta.Controllers;

public class BaseController : Controller
{
    private readonly AuthController _authController;

    public BaseController(AuthController authController)
    {
        _authController = authController;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (Request.Cookies.TryGetValue("AuthToken", out var token))
        {
            bool usuario = _authController.ValidarJwtToken(token);

            if (usuario)
            {
                //ViewBag.Usuario = usuario.Identity.Name;
                return;
            }
        }

        // Se não estiver autenticado, redireciona para a página de login
        context.Result = new RedirectToActionResult("Login", "Auth", null);
    }
}