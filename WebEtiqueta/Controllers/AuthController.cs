using Microsoft.AspNetCore.Mvc;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Services;

namespace WebEtiqueta.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string id)
        {

            if(id != null && !string.IsNullOrEmpty(id.Trim()))
            {
                Resposta<MatrizModel> matriz = await _authService.PegarMatrizPorCnpjCpf(id);
            
                TempData["AlertaTipo"]      = matriz.status ? "success" : "danger";
                TempData["AlertaMensagem"]  = matriz.mensagem;
                TempData["LogSuporte"]      = matriz.logSuporte;

                if (matriz.status)
                    ViewBag.Matriz = matriz.dados;
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
        public async Task<IActionResult> ValidarLogin(String usuarioLogin, String usuarioSenha)
        {
            usuarioLogin = usuarioLogin.Trim().ToLower();
            usuarioSenha = usuarioSenha.Trim();
            if (string.IsNullOrEmpty(usuarioLogin) || string.IsNullOrEmpty(usuarioSenha))
            {
                return StatusCode(400, new
                {
                    Status      = false,
                    Mensagem    = "Login e Senha são obrigatórios",
                    LogSuporte  = "Login e Senha são obrigatórios"
                });
            }

            Resposta<UsuarioModel> usuario = await _authService.ValidarLogin(usuarioLogin, usuarioSenha);
            if (!usuario.status)
            {
                return StatusCode(401, new
                {
                    Status      = usuario.status,
                    Mensagem    = usuario.mensagem,
                    LogSuporte  = usuario.logSuporte
                });
            }

            //MatrizModel matriz = usuario.dados.Matriz;
            
            Resposta<String> jwt = _authService.GerarJwtToken(usuario.dados);
            if(!jwt.status)
            {
                return StatusCode(500, new
                {
                    Status      = jwt.status,
                    Mensagem    = jwt.mensagem,
                    LogSuporte  = jwt.logSuporte
                });
            }

            // Criando o cookie
            Response.Cookies.Append("AuthToken", jwt.dados, new CookieOptions
            {
                HttpOnly    = true,   // Protege contra acesso via JavaScript
                Secure      = false,    // ⚠️ Use `true` em produção (HTTPS)
                SameSite    = SameSiteMode.Lax, // Permite envio em navegação normal
                Expires     = DateTime.UtcNow.AddDays(1) // Tempo de expiração
            });

            HttpContext.Session.SetString("UsuarioNome", usuario.dados.Nome);
            HttpContext.Session.SetInt32("UsuarioId", usuario.dados.Id);
            //HttpContext.Session.SetInt32("MatrizCnpjCpf", usuario.dados.MatrizId);

            return StatusCode(200, new
            {
                Status      = true,
                Mensagem    = "Usuário autenticado com sucesso",
            });
        }
    }
}
