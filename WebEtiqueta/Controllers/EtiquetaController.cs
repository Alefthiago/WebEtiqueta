using Microsoft.AspNetCore.Mvc;

namespace WebEtiqueta.Controllers
{
    public class EtiquetaController : BaseController
    {
        private readonly ILogger<EtiquetaController> _logger;

        // Injeção do ILogger e do AuthController
        public EtiquetaController(ILogger<EtiquetaController> logger, AuthController authController)
            : base(authController)  // Passando o AuthController para o construtor da classe BaseController
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult A4()
        {
            return View("~/Views/Etiqueta/A4/Lista.cshtml");
        }
    }
}
