using Microsoft.AspNetCore.Mvc;

namespace WebEtiqueta.Controllers
{
    public class EtiquetaController : Controller
    {
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
