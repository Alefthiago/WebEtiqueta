using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;

namespace WebEtiqueta.Repositorys
{
    public class AuthRepository
    {
        private readonly Contexto _contexto;
        private readonly IConfiguration _configuration;
        public AuthRepository(Contexto contexto, IConfiguration configuration)
        {
            _contexto = contexto;
            _configuration = configuration;
        }
        
        public async Task<Resposta<MatrizModel>?> PegarMatrizPorCnpjCpf(string cnpjCpf)
        {
            try
            {
                var resultado = await _contexto.Matriz
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.CnpjCpf == cnpjCpf);
                if(resultado != null)
                {
                    return new Resposta<MatrizModel>(resultado);
                }

                return null;
            } catch (Exception e)
            {
                return new Resposta<MatrizModel>("Erro ao buscar matriz, tente novamente mais tarde ou entre em contato com o suporte!", $"AuthRepository/PegarMatrizPorCnpjCpf: {e.Message}");
            }
        }

        public async Task<Resposta<UsuarioModel>?> ValidarLogin(string login, string cnpjCpf)
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
                            Senha = usuario.Senha,
                            Elimnado = usuario.Eliminado,
                            MatrizCnpjCpf = matriz.CnpjCpf
                        }
                    )
                    .Where(x => x.Elimnado == false && x.Login == login && x.MatrizCnpjCpf == cnpjCpf)
                    .FirstOrDefaultAsync();
                if (resultado != null)
                {
                    UsuarioModel usuario = new UsuarioModel
                    {
                        Login = resultado.Login,
                        Senha = resultado.Senha
                    };
                    return new Resposta<UsuarioModel>(usuario);
                }

                return null;
            }
            catch (Exception e)
            {
                return new Resposta<UsuarioModel>("Erro ao autenticar usuário, tente novamente mais tarde ou entre em contato com o suporte!", $"AuthRepository/ValidaLogin: {e.Message}");
            }
        }

        public Resposta<string> ValidarSenhaSuporte(string senha)
        {
            try
            {
                string senhaSuporte = _configuration.GetSection("SenhaSuporte").Value;
                return new Resposta<string>(senhaSuporte);
            } catch (Exception e)
            {
                return new Resposta<string>(mensagem: "Erro ao validar senha de suporte, tente novamente mais tarde ou entre em contato com o suporte!", $"AuthRepository/ValidarSenhaSuporte: {e.Message}");
            }
        }
    }
}
