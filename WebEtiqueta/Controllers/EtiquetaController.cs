using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using WebEtiqueta.Services;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;

namespace WebEtiqueta.Controllers
{
    public class EtiquetaController : BaseController
    {
        private readonly ILogger<EtiquetaController> _logger;
        private readonly EtiquetaService _etiquetaService;

        public EtiquetaController(ILogger<EtiquetaController> logger, IConfiguration configuration)
            : base(configuration)  // Passando a configuração corretamente
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

        [HttpGet]
        public async Task<IActionResult> PegarTodasEtiquetas()
        {
            var dadosToken = (Dictionary<string, string>)HttpContext.Items["DadosToken"];
            Resposta<List<EtiquetaModel>> etiquetas = await _etiquetaService.ListarEtiquetas(dadosToken);


            return null;
        }
    }
}