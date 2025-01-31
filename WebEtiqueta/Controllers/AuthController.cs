using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebEtiqueta.Models;

namespace WebEtiqueta.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        private readonly Contexto _contexto;

        public AuthController(IConfiguration config, Contexto contexto)
        {
            _config = config;
            _contexto = contexto;
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");

            return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        public async Task<IActionResult> ValidarLogin(String usuarioLogin, String usuarioSenha)
        {
            if (string.IsNullOrEmpty(usuarioLogin) || string.IsNullOrEmpty(usuarioSenha))
            {
                return StatusCode(400, new
                {
                    Msg = "Login e Senha são obrigatórios"
                });
            }

            UsuarioModel? usuario = await DadosLogin(usuarioLogin, usuarioSenha);

            if (usuario == null)
            {
                return StatusCode(401, new
                {
                    Msg = "Usuário ou senha inválidos"
                });
            }

            string jwt = GerarJwtToken(usuario);

            if(string.IsNullOrEmpty(jwt))
            {
                return StatusCode(500, new
                {
                    Msg = "Erro ao gerar token, tente novamente mais tarde ou entre em contato com nosso suporte"
                });
            }

            // Criando o cookie
            Response.Cookies.Append("AuthToken", jwt, new CookieOptions
            {
                HttpOnly = true,   // Protege contra acesso via JavaScript
                Secure = false,    // ⚠️ Use `true` em produção (HTTPS)
                SameSite = SameSiteMode.Lax, // Permite envio em navegação normal
                Expires = DateTime.UtcNow.AddDays(1) // Tempo de expiração
            });

            return StatusCode(200, new
            {
                Msg = "Usuário autenticado",
            });
        }

        public string GerarJwtToken(UsuarioModel usuario)
        {
            try
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim("Nome", usuario.Nome),
                    //new Claim("", usuario.Id.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("JwtSettings:SecretKey").Value));
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool ValidarJwtToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]);

                var parametrosValidacao = new TokenValidationParameters
                {
                    ValidateIssuer = false, // Defina como true se quiser validar o emissor
                    ValidateAudience = false, // Defina como true se quiser validar a audiência
                    ValidateLifetime = true, // Verifica se o token expirou
                    ValidateIssuerSigningKey = true, // Verifica a assinatura
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero // Evita que o token continue válido por um pequeno período após a expiração
                };

                var principal = tokenHandler.ValidateToken(token, parametrosValidacao, out _);
                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

        private async Task<UsuarioModel>? DadosLogin(string login, string senha)
        {
            try
            {
                var resultado = await _contexto.Usuario
                    .Where(u => u.Login == login) 
                    .FirstOrDefaultAsync();

                if (resultado != null && resultado.VerificarSenhaLogin(senha))
                {
                    return resultado;
                }

                return null;
            } catch (Exception ex)
            {
                return null;
            }
        }
    }
}
