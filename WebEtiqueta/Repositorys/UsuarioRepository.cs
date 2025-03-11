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
        public async Task<Resposta<UsuarioModel>?> LoginUsuarioPorLoginCnpjCpf(string loginUsuario, string cnpjCpfMatriz)
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
                            usuario,
                            matriz
                        }
                    )
                    .Join(
                        _contexto.NivelAcesso,
                        usuarioMatriz => usuarioMatriz.usuario.NivelAcessoId,
                        nivelAcesso => nivelAcesso.Id,
                        (usuarioMatriz, nivelAcesso) => new
                        {
                            usuarioMatriz.usuario,
                            usuarioMatriz.matriz,
                            nivelAcesso
                        }
                    )
                    .FirstOrDefaultAsync(resultado =>
                        resultado.usuario.Eliminado == false &&
                        resultado.matriz.CnpjCpf == cnpjCpfMatriz &&
                        resultado.usuario.Login == loginUsuario
                    );
                if (resultado != null)
                {
                    if (!string.IsNullOrWhiteSpace(resultado.usuario.Login) && !string.IsNullOrWhiteSpace(resultado.usuario.Senha))
                    {
                        UsuarioModel usuario = new UsuarioModel
                        {
                            Login   = resultado.usuario.Login,
                            Nome    = resultado.usuario.Nome,
                            Senha   = resultado.usuario.Senha,
                            Matriz  = new MatrizModel { CnpjCpf = resultado.matriz.CnpjCpf},
                            NivelAcesso = resultado.nivelAcesso
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

        public async Task<Resposta<NivelAcessoModel>?> PegarNivelAcessoPorUsuario(string login, string matriz)
        {
            try
            {
                var resultado = await (from nivelAcesso in _contexto.NivelAcesso
                                join usuario in _contexto.Usuario
                                on nivelAcesso.Id equals usuario.NivelAcessoId
                                join matrizModel in _contexto.Matriz
                                on usuario.MatrizId equals matrizModel.Id
                                where usuario.Login == login && matrizModel.CnpjCpf == matriz
                                select nivelAcesso).FirstOrDefaultAsync();
                if (resultado != null)
                {
                    return new Resposta<NivelAcessoModel>(resultado);
                }
                return null;
            }
            catch (Exception e)
            {
                return new Resposta<NivelAcessoModel>(
                    $"Erro ao buscar nível de acesso!", 
                    $"UsuarioRepository/PegarNivelAcessoPorUsuario: {e.Message}"
                );
            }
        }
    }
}
