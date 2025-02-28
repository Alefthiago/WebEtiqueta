using Microsoft.AspNetCore.Mvc;
using WebEtiqueta.Services;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Models.Forms;

namespace WebEtiqueta.Controllers
{
    public class EtiquetaController : BaseController
    {
        private readonly ILogger<EtiquetaController> _logger;
        private readonly EtiquetaService _etiquetaService;

        public EtiquetaController(ILogger<EtiquetaController> logger, IConfiguration configuration, EtiquetaService etiquetaService)
            : base(configuration)  // Passando a configuração corretamente
        {
            _logger = logger;
            _etiquetaService = etiquetaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Adicionar()
        {
            return View("Adicionar");
        }
        [HttpPost]
        public async Task<IActionResult> AdicionarExe(AdicionarEtiquetaViewModel form)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var erros = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                    TempData["AlertaTipo"]      = "danger";
                    TempData["AlertaMensagem"]  = erros;
                    return RedirectToAction("Adicionar");
                }
                else
                {
                    string matriz = HttpContext.Session.GetString("Matriz");
                    Resposta<bool> etiquetaAdicionada = await _etiquetaService.AdicionarEtiqueta(form, matriz);
                    
                    TempData["AlertaTipo"]      = etiquetaAdicionada.Status ? "success" : "danger";
                    TempData["AlertaMensagem"]  = etiquetaAdicionada.Mensagem;
                    TempData["LogSuporte"]      = etiquetaAdicionada.LogSuporte;
                    return RedirectToAction(etiquetaAdicionada.Status ? "Index" : "Adicionar");
                }
            } catch (Exception e)
            {
                TempData["AlertaTipo"]      = "danger";
                TempData["AlertaMensagem"]  = "Erro inesperado ao adicionar etiqueta, tente novamente mais tarde ou entre em contato com nosso suporte";
                TempData["LogSuporte"]      = $"EtiquetaController/AdicionarExe: {e.Message}";
                return RedirectToAction("Adicionar");
            }
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