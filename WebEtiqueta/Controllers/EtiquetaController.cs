using Microsoft.AspNetCore.Mvc;

namespace WebEtiqueta.Controllers
{
    public class EtiquetaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
