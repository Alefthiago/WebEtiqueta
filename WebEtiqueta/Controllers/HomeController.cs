using Microsoft.AspNetCore.Mvc;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Services;

namespace WebEtiqueta.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeService _homeService;

        public HomeController(
            ILogger<HomeController> logger, 
            IConfiguration configuration,
            HomeService homeService
        )
            : base(configuration)
        {
            _logger         = logger;
            _homeService    = homeService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            //var dadosToken = (Dictionary<string, string>)HttpContext.Items["DadosToken"];
            //if(!etiquetas.status)
            //{
            //    TempData["AlertaTipo"]          = "danger";
            //    TempData["AlertaMensagem"]      = etiquetas.mensagem;
            //    TempData["AlertaLogSuporte"]    = etiquetas.logSuporte;
            //} else
            //{
            //    ViewBag.Etiquetas = etiquetas.dados;
            //}
           
            return View();
        }
    }
}