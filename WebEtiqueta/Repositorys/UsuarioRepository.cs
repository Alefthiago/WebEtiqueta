using Microsoft.EntityFrameworkCore;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;

namespace WebEtiqueta.Repositorys
{
    public class UsuarioRepository
    {
        private readonly Contexto _contexto;
        public UsuarioRepository(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<Resposta<UsuarioModel>?> PegarUsuarioPorLoginCnpjCpf(string loginUsuario, string cnpjCpfMatriz)
        {
            try
            {
                var resultado = await _contexto.Usuario
                .AsNoTracking()
                    .Join(
                        _contexto.Matriz,
                        usuario => usuario.MatrizId,
                        matriz => matriz.Id,
                        (usuario, matriz) => new
                        {
                            Login = usuario.Login,
                            Nome = usuario.Nome,
                            Senha = usuario.Senha,
                            Elimnado = usuario.Eliminado,
                            MatrizCnpjCpf = matriz.CnpjCpf
                        }
                    )
                    .FirstOrDefaultAsync(x =>
                        !x.Elimnado &&
                        x.Login == loginUsuario &&
                        x.MatrizCnpjCpf == cnpjCpfMatriz
                    );
                if (resultado != null)
                {
                    if (!string.IsNullOrWhiteSpace(resultado.Login) && !string.IsNullOrWhiteSpace(resultado.Senha))
                    {
                        UsuarioModel usuario = new UsuarioModel
                        {
                            Login = resultado.Login,
                            Nome = resultado.Nome,
                            Senha = resultado.Senha,
                            Matriz = new MatrizModel { CnpjCpf = resultado.MatrizCnpjCpf }
                        };
                        return new Resposta<UsuarioModel>(usuario);
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                return new Resposta<UsuarioModel>(
                    "Erro ao autenticar usuário, tente novamente mais tarde ou entre em contato com o suporte!",
                    $"AuthRepository/ValidaLogin: {e.Message}"
                );
            }
        }
    }
}
