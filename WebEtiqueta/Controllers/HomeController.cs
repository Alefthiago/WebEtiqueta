using Microsoft.AspNetCore.Mvc;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
namespace WebEtiqueta.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthController _authController;

        // Inje��o do ILogger e do AuthController
        public HomeController(ILogger<HomeController> logger, AuthController authController)
            : base(authController)  // Passando o AuthController para o construtor da classe BaseController
        {
            _logger = logger;
            _authController = authController;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(Request.Cookies["AuthToken"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            Dictionary<string, string> dadosToken = Helpers.Jwt.DadosToken(Request.Cookies["AuthToken"]); // ["UsuarioId"] ["MatriId"]

            return View();
        }
    }
}