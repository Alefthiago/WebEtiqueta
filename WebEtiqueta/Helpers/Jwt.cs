using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebEtiqueta.Models;

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

        public static Resposta<String> GerarJwtToken(UsuarioModel usuario, string secretKey)
        {
            try
            {
                if (usuario == null || string.IsNullOrWhiteSpace(usuario.Login) || string.IsNullOrWhiteSpace(usuario.Empresa.CnpjCpf))
                {
                    return new Resposta<string>("Informe os dados do Usuário");
                }
                List<Claim> claims = new List<Claim>
                {
                    new Claim("UsuarioLogin", Convert.ToString(usuario.Login)),
                    new Claim("Empresa", Convert.ToString(usuario.Empresa.CnpjCpf))
                };

                if (string.IsNullOrWhiteSpace(secretKey)) return new Resposta<string>("Chave de segurança não configurada");

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return new Resposta<string>()
                {
                    Status = true,
                    Dados = jwt,
                    Mensagem = "Token gerado com sucesso"
                };
            }
            catch (Exception e)
            {
                return new Resposta<string>(mensagem: "Erro ao gerar token, tente novamente mais tarde ou entre em contato com nosso suporte", logSuporte: e.Message);
            }
        }
    }
}
