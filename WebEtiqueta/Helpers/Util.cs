using Microsoft.AspNetCore.Identity;
using WebEtiqueta.Models;

namespace WebEtiqueta.Helpers
{
    public static class Util
    {
        public static bool CompararSenha(UsuarioModel usuario, string senha)
        {
            var hasher = new PasswordHasher<string>();
            var senhaValida = hasher.VerifyHashedPassword(usuario.Login, usuario.Senha, senha);

            if (senhaValida == PasswordVerificationResult.Success)
            {
                return true;
            }

            return false;
        }
    }
}
