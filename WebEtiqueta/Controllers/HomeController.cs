using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebEtiqueta.Models;
using Microsoft.Extensions.Configuration;

namespace WebEtiqueta.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        // Injeção do ILogger e do AuthController
        public HomeController(ILogger<HomeController> logger, AuthController authController)
            : base(authController)  // Passando o AuthController para o construtor da classe BaseController
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
