using Microsoft.EntityFrameworkCore;
using WebEtiqueta.Models;

namespace WebEtiqueta.Services
{
    public class UsuarioService
    {
        private readonly Contexto _contexto;

        public UsuarioService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<UsuarioModel> buscarUsuarioPorLogin(String login)
        {
            return await _contexto.Set<UsuarioModel>()
                .FirstOrDefaultAsync(usuario => usuario.Login == login);
        }
    }
}
