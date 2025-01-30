using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            return StatusCode(200, new
            {
                Msg = "ok"
            });
            //var retorno = await VerificarUsuarioLogin(_contexto);
            //var senhaHash = new PasswordHasher<string>().HashPassword(usuarioLogin, usuarioSenha);


            //UsuarioModel usuario = new UsuarioModel(
            //    usuarioLogin,
            //    senhaHash
            //);
            //return Json(new
            //{
            //    StatusCode = 200,
            //    Message = retorno
            //});
            //return StatusCode(401);

            //return Json(new
            //{
            //    StatusCode = 200,
            //    Message = senhaHash
            //});
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
                return ex.Message;
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
                return false; // Retorna nulo caso o token seja inválido
            }
        }

        //private async Task<string>? VerificarUsuarioLogin(Contexto contexto)
        //{
        //    // Verificar se o login existe no banco de dados
        //    var resultado = await contexto.Usuario
        //        .Where(u => u.Login == this.Login)  // Filtro correto para o login
        //        .FirstOrDefaultAsync();

        //    if (resultado != null)
        //    {
        //        return resultado.Senha;  // Retorna a senha se o usuário for encontrado
        //    }

        //    return null;  // Caso contrário, retorna null
        //}
    }
}
