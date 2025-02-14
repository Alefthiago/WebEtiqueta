using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebEtiqueta.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, IConfiguration configuration)
            : base(configuration)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Login");
        }
    }
}