using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebEtiqueta.Helpers;
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
            usuarioLogin = usuarioLogin.Trim().ToLower();
            usuarioSenha = usuarioSenha.Trim();

            if (string.IsNullOrEmpty(usuarioLogin) || string.IsNullOrEmpty(usuarioSenha))
            {
                return StatusCode(400, new
                {
                    Msg = "Login e Senha são obrigatórios"
                });
            }

            //var hasher = new PasswordHasher<string>();
            //var senha = hasher.HashPassword(usuarioLogin, usuarioSenha);
            //return StatusCode(200,
            //   new
            //   {
            //       Msg = senha
            //   }
            //);

            Resposta<UsuarioModel> usuario = await DadosLogin(usuarioLogin, usuarioSenha);

            if (!usuario.status)
            {
                return StatusCode(401, new
                {
                    Msg = usuario.mensagem
                });
            }

            Resposta<String> jwt = GerarJwtToken(usuario.dados);

            if(!jwt.status)
            {
                return StatusCode(500, new
                {
                    Msg = jwt.mensagem
                });
            }

            // Criando o cookie
            Response.Cookies.Append("AuthToken", jwt.dados, new CookieOptions
            {
                HttpOnly = true,   // Protege contra acesso via JavaScript
                Secure = false,    // ⚠️ Use `true` em produção (HTTPS)
                SameSite = SameSiteMode.Lax, // Permite envio em navegação normal
                Expires = DateTime.UtcNow.AddDays(1) // Tempo de expiração
            });

            return StatusCode(200, new
            {
                Msg = "Usuário autenticado com sucesso",
            });
        }

        public Resposta<String> GerarJwtToken(UsuarioModel usuario)
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

                return new Resposta<string>(
                    true,
                    "Token gerado com sucesso",
                    jwt
                );

            }
            catch (Exception ex)
            {
                return new Resposta<string>(
                    false,
                    "Erro ao gerar token, tente novamente mais tarde ou entre em contato com nosso suporte"
                );
            }
        }

        public bool ValidarJwtToken(string token) // validado ao realizar qualquer requisição para a aplicação
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

        private async Task<Resposta<UsuarioModel>> DadosLogin(string login, string senha)
        {
            try
            {
                var resultado = await _contexto.Usuario
                    .Where(u => u.Login == login) 
                    .FirstOrDefaultAsync();
                
                if (resultado != null && resultado.VerificarSenhaLogin(senha))
                {
                    return new Resposta<UsuarioModel>(
                        true,
                        "Usuário autenticado",
                        resultado
                    );
                }

                return new Resposta<UsuarioModel>(
                    false,
                    "Usuário ou senha inválidos!"
                );
            } catch (Exception ex)
            {
                return new Resposta<UsuarioModel>(
                    false,
                    "Erro ao autenticar usuário, tente novamente mais tarde ou entre em contato com o suporte!"
                );
            }
        }
    }
}
