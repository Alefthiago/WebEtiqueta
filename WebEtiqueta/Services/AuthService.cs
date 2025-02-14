using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;

namespace WebEtiqueta.Services
{
    public class AuthService
    {
        private readonly Contexto _contexto;
        private readonly IConfiguration _config;
        public AuthService(Contexto contexto, IConfiguration config)
        {
            _contexto = contexto;
            _config = config;
        }

        public Resposta<String> GerarJwtToken(UsuarioModel usuario)
        {
            try
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim("UsuarioId", Convert.ToString(usuario.Id)),
                    new Claim("MatrizId", Convert.ToString(usuario.MatrizId))
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
            catch
            {
                return new Resposta<string>(
                    false,
                    "Erro ao gerar token, tente novamente mais tarde ou entre em contato com nosso suporte"
                );
            }
        }

        public async Task<Resposta<UsuarioModel>> ValidarLogin(string login, string senha)
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
            }
            catch
            {
                return new Resposta<UsuarioModel>(
                    false,
                    "Erro ao autenticar usuário, tente novamente mais tarde ou entre em contato com o suporte!"
                );
            }
        }
    }
}