using System.IdentityModel.Tokens.Jwt;

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
    }
}
