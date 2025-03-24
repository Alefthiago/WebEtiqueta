using Microsoft.AspNetCore.Mvc;
using WebEtiqueta.Services;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Models.Forms;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace WebEtiqueta.Controllers
{
    public class EtiquetaController : BaseController
    {
        private readonly ILogger<EtiquetaController> _logger;
        private readonly EtiquetaService _etiquetaService;
        private readonly IConfiguration _config;
        public EtiquetaController(ILogger<EtiquetaController> logger, IConfiguration configuration, EtiquetaService etiquetaService)
            : base(configuration)
        {
            _logger = logger;
            _etiquetaService = etiquetaService;
            _config = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Adicionar()
        {
            try
            {
                //      VALIDAÇÃO DE NÍVEL DE ACESSO.       //
                var resultado = ValidacoesPadrao.ValidarNivelAcesso(HttpContext, _config);
                if (!resultado.Status)
                {
                    TempData["AlertaTipo"] = "danger";
                    TempData["AlertaMensagem"] = resultado.Mensagem;
                    return RedirectToAction("Login", "Auth");
                }
                NivelAcessoModel? nivelAcesso =  JsonSerializer.Deserialize<NivelAcessoModel>(HttpContext.Session.GetString("NivelAcesso"));
                if (nivelAcesso != null && (nivelAcesso.AdicionarEtiqueta || nivelAcesso.Id == int.Parse(_config.GetSection("Suporte:NivelAcessoId").Value)))
                {
                    return View("Adicionar");
                }
                else
                {
                    TempData["AlertaTipo"]      = "danger";
                    TempData["AlertaMensagem"]  = "Você não tem permissão para adicionar etiquetas";
                    return RedirectToAction("Index");
                }
                //     /VALIDAÇÃO DE NÍVEL DE ACESSO.       //
            }
            catch (Exception e)
            {
                TempData["AlertaTipo"]      = "danger";
                TempData["AlertaMensagem"]  = "Erro inesperado ao acessar a página de adicionar etiqueta, tente novamente mais tarde ou entre em contato com nosso suporte";
                TempData["LogSuporte"]      = $"EtiquetaController/Adicionar: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AdicionarExe(AdicionarEtiquetaViewModel form)
        {
            try
            {
                //      VALIDAÇÃO DE NÍVEL DE ACESSO.       //
                Resposta<bool> nivelAcessoValidado = ValidacoesPadrao.ValidarNivelAcesso(HttpContext, _config);
                if (!nivelAcessoValidado.Status)
                {
                    TempData["AlertaTipo"]      = "danger";
                    TempData["AlertaMensagem"]  = nivelAcessoValidado.Mensagem;
                    TempData["LogSuporte"]      = nivelAcessoValidado.LogSuporte ?? null;
                    return RedirectToAction("Login", "Auth");
                }

                NivelAcessoModel? nivelAcesso = JsonSerializer.Deserialize<NivelAcessoModel>(HttpContext.Session.GetString("NivelAcesso"));
                if (nivelAcesso.Id != int.Parse(_config.GetSection("Suporte:NivelAcessoId").Value) && !nivelAcesso.AdicionarEtiqueta)
                {
                    TempData["AlertaTipo"]      = "danger";
                    TempData["AlertaMensagem"]  = "Você não tem permissão para adicionar etiquetas";
                    return RedirectToAction("Index");
                }
                //     /VALIDAÇÃO DE NÍVEL DE ACESSO.       //

                if (!ModelState.IsValid)
                {
                    //     VALIDAÇÃO DE FORMULÁRIO.     //
                    var erros = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                    TempData["AlertaTipo"]      = "danger";
                    TempData["AlertaMensagem"]  = erros;
                    return RedirectToAction("Adicionar");
                    //    /VALIDAÇÃO DE FORMULÁRIO.     //
                }
                else
                {
                    Resposta<bool> etiquetaAdicionada = await _etiquetaService.AdicionarEtiqueta(form, "askdçjasdklj");
                    
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