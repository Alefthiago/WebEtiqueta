using Microsoft.AspNetCore.Mvc;

namespace WebEtiqueta.Controllers
{
    public class FilialController : BaseController
    {
        private readonly IConfiguration _config;

        public FilialController(IConfiguration configuration)
        : base(configuration)
        {
            _config = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
