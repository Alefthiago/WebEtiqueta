using Microsoft.AspNetCore.Mvc;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Services;

namespace WebEtiqueta.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;
        private readonly EmpresaService _EmpresaService;
        private readonly IConfiguration _config;
        protected string? _nivelAcessoSuporteId;

        public AuthController(AuthService authService, IConfiguration config, EmpresaService empresaService)
        {
            _authService            = authService;
            _config                 = config;
            _EmpresaService          = empresaService;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string id)
        {
            if(!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if(!Util.ValidaDocumento(id))
                    {
                        TempData["AlertaTipo"]      = "danger";
                        TempData["AlertaMensagem"]  = "CNPJ/CPF inválido";
                        return View("Login");
                    }

                    Resposta<EmpresaModel> empresa = await _EmpresaService.PegarEmpresaPorCnpjCpf(id);
                    if (!empresa.Status || empresa.Dados == default)
                    {
                        TempData["AlertaTipo"]      = "danger";
                        TempData["AlertaMensagem"]  = empresa.Mensagem ?? "Não foi possível carregar os dados";
                        TempData["LogSuporte"]      = empresa.LogSuporte;
                    } else
                    {
                        ViewBag.Empresa = new
                        {
                            Nome    = empresa.Dados.Nome,
                            CnpjCpf = empresa.Dados.CnpjCpf
                        };
                    }
                }
                catch (Exception e)
                {
                    TempData["AlertaTipo"]      = "danger";
                    TempData["AlertaMensagem"]  = "Erro ao buscar empresa, tente novamente mais tarde ou entre em contato com o suporte!";
                    TempData["LogSuporte"]      = $"AuthService/PegarEmpresaPorCnpjCpf: {e.Message}";
                }
            }
            return View("Login");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        public async Task<IActionResult> LoginExe(String usuarioLogin, String usuarioSenha, string empresaCnpjCpf)
        {
            //      VALIDAÇÃO BÁSICA.       //
            if (string.IsNullOrWhiteSpace(usuarioLogin) || string.IsNullOrWhiteSpace(usuarioSenha) || string.IsNullOrWhiteSpace(empresaCnpjCpf))
            {
                return StatusCode(400, new
                {
                    status      = false,
                    mensagem    = "Todos os dados são obrigatórios"
                });
            }
            //     /VALIDAÇÃO BÁSICA.       //

            try
            {
                Resposta<UsuarioModel> usuarioConsulta = await _authService.ValidarLogin(
                    usuarioLogin.Trim().ToLower(),
                    usuarioSenha.Trim().ToLower(),
                    empresaCnpjCpf.Trim().ToLower()
                );

                if (!usuarioConsulta.Status)
                {
                    return StatusCode(400, new
                    {
                        status      = usuarioConsulta.Status,
                        mensagem    = usuarioConsulta.Mensagem,
                        logSuporte  = usuarioConsulta.LogSuporte
                    });
                }

                if (usuarioConsulta.Dados != null && usuarioConsulta.Dados != default)
                {
                    UsuarioModel usuario = usuarioConsulta.Dados;

                    string? secretKey = _config.GetSection("JwtSettings:SecretKey").Value;
                    if(string.IsNullOrWhiteSpace(secretKey))
                    {
                        return StatusCode(400, new
                        {
                            status      = false,
                            mensagem    = "Chave de segurança não configurada"
                        });
                    }

                    Resposta<String> jwt = Jwt.GerarJwtToken(usuario, secretKey);
                    if (!jwt.Status)
                    {
                        return StatusCode(400, new
                        {
                            status      = jwt.Status,
                            mensagem    = jwt.Mensagem,
                            logSuporte  = jwt.LogSuporte
                        });
                    }

                    if(string.IsNullOrWhiteSpace(jwt.Dados))
                    {
                        return StatusCode(400, new
                        {
                            status      = false,
                            mensagem    = "Erro ao gerar token de autenticação"
                        });
                    }

                    // CREIÇÃO DE COOKIE
                    Response.Cookies.Append("AuthToken", jwt.Dados, new CookieOptions
                    {
                        HttpOnly    = true,   // Protege contra acesso via JavaScript
                        Secure      = false,    // ⚠️ Use `true` em produção (HTTPS)
                        SameSite    = SameSiteMode.Lax, // Permite envio em navegação normal
                        Expires     = DateTime.UtcNow.AddDays(1) // Tempo de expiração
                    });

                    // CRIAÇÃO DE SESSÃO
                    string nivelAcesso = System.Text.Json.JsonSerializer.Serialize(usuario.NivelAcesso);
                    HttpContext.Session.SetString("NivelAcesso", nivelAcesso);
                    HttpContext.Session.SetString("UsuarioLogin", usuario.Login);
                    HttpContext.Session.SetString("UsuarioId", usuario.Id.ToString());
                    HttpContext.Session.SetString("Empresa", usuario.Empresa.CnpjCpf);

                    return StatusCode(200, new
                    {
                        status      = true,
                        mensagem    = "Usuário autenticado com sucesso"
                    });
                }

                return StatusCode(400, new
                {
                    status      = false,
                    mensagem    = "Usuário não encontrado"
                });
            } catch (Exception e)
            {
                return StatusCode(500, new
                {
                    status      = false,
                    mensagem    = "Erro ao autenticar usuário, tente novamente mais tarde ou entre em contato com o suporte",
                    logSuporte  = $"AuthController/ValidarLogin: {e.Message}"
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SenhaSuporte(string suporteSenha)
        {
            if (string.IsNullOrWhiteSpace(suporteSenha))
            {
                return StatusCode(400, new
                {
                    status      = false,
                    mensagem    = "Senha obrigatória"
                });
            }

            try
            {
                string senha                = suporteSenha;
                Resposta<bool> autorizado   = await _authService.ValidarSenhaSuporte(senha);
                if (!autorizado.Status)
                {
                    return StatusCode(400, new
                    {
                        status      = autorizado.Status,
                        mensagem    = autorizado.Mensagem,
                        logSuporte  = autorizado.LogSuporte
                    });
                }
                else if (!autorizado.Dados)
                {
                    return StatusCode(402, new
                    {
                        status      = false,
                        mensagem    = "Acesso não autorizado"
                    });
                }

                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    status      = false,
                    mensagem    = "Erro ao validar senha de suporte, tente novamente mais tarde ou entre em contato com o suporte",
                    logSuporte  = $"AuthController/SenhaSuporte: {e.Message}"
                });
            }
        }
    }
}