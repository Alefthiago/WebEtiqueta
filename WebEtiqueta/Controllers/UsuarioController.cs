using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebEtiqueta.Models;

namespace WebEtiqueta.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, AuthController authController)
            : base(authController)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Login");
        }
    }
}
