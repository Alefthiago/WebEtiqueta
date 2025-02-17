using Microsoft.EntityFrameworkCore;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;

namespace WebEtiqueta.Repositorys
{
    public class AuthRepository
    {
        private readonly Contexto _contexto;

        public AuthRepository(Contexto contexto)
        {
            _contexto = contexto;
        }
        
        public async Task<Resposta<MatrizModel>> PegarMatrizPorCnpjCpf(string documento)
        {
            try
            {
                var resultado = await _contexto.Matriz
                    .Where(m => m.CnpjCpf == documento)
                    .FirstOrDefaultAsync();
                if(resultado != null)
                {
                    return new Resposta<MatrizModel>(
                        status: true,
                        mensagem: "Matriz encontrada",
                        dados: resultado
                    );
                }

                return new Resposta<MatrizModel>(
                    status: false,
                    mensagem: "Matriz não encontrada"
                );
            } catch (Exception e)
            {
                return new Resposta<MatrizModel>(
                    status: false,
                    mensagem: "Erro ao buscar matriz, tente novamente mais tarde ou entre em contato com o suporte!",
                    logSuporte: $"AuthRepository/PegarMatrizPorCnpjCpf: {e.Message}"
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
                        status: true,
                        mensagem: "Usuário autenticado",
                        dados: resultado
                    );
                }

                return new Resposta<UsuarioModel>(
                    status: false,
                    mensagem: "Usuário ou senha inválidos!"
                );
            }
            catch (Exception e)
            {
                return new Resposta<UsuarioModel>(
                    status: false,
                    mensagem: "Erro ao autenticar usuário, tente novamente mais tarde ou entre em contato com o suporte!",
                    logSuporte: $"AuthRepository/ValidaLogin: {e.Message}"
                );
            }
        }
    }
}
