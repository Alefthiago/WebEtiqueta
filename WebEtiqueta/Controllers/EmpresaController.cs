using Microsoft.AspNetCore.Mvc;

namespace WebEtiqueta.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
