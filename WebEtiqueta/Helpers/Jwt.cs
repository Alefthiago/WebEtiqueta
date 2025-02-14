using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebEtiqueta.Helpers
{
    public static class  Jwt
    {
        public static Dictionary<string, string> DadosToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            return jsonToken.Claims.ToDictionary(c => c.Type, c => c.Value);
        }

        public static bool ValidarJwtToken(string token, IConfiguration config) // validado ao realizar qualquer requisição para a aplicação
        {

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(config["JwtSettings:SecretKey"]);

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
            catch
            {
                return false;
            }
        }
    }
}
