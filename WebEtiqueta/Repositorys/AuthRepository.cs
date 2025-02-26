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
                    if (!string.IsNullOrWhiteSpace(resultado.Nome) && !string.IsNullOrWhiteSpace(resultado.CnpjCpf))
                    {
                        return new Resposta<MatrizModel>(resultado);
                    }
                }

                return null;
            } catch (Exception e)
            {
                return new Resposta<MatrizModel>(
                    "Erro ao buscar matriz, tente novamente mais tarde ou entre em contato com o suporte!", 
                    $"AuthRepository/PegarMatrizPorCnpjCpf: {e.Message}"
                );
            }
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
                            Login           = usuario.Login,
                            Nome            = usuario.Nome,
                            Senha           = usuario.Senha,
                            Elimnado        = usuario.Eliminado,
                            MatrizCnpjCpf   = matriz.CnpjCpf
                        }
                    )
                    .FirstOrDefaultAsync(x => 
                        !x.Elimnado && 
                        x.Login == loginUsuario && 
                        x.MatrizCnpjCpf == cnpjCpfMatriz
                    );
                if (resultado != null)
                {
                    if(!string.IsNullOrWhiteSpace(resultado.Login) && !string.IsNullOrWhiteSpace(resultado.Senha))
                    {
                        UsuarioModel usuario = new UsuarioModel
                        {
                            Login   = resultado.Login,
                            Nome    = resultado.Nome,
                            Senha   = resultado.Senha,
                            Matriz  = new MatrizModel { CnpjCpf = resultado.MatrizCnpjCpf }
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

        public Resposta<string>? SenhaSuporte(string senha)
        {
            try
            {
                //string? senhaSuporte = _configuration.GetValue<string>("Suprote:SenhaSuporte");
                string? senhaSuporte = _configuration.GetSection("Suporte:SenhaSuporte").Value;
                Console.WriteLine(senhaSuporte);
                if (!string.IsNullOrWhiteSpace(senhaSuporte) && senhaSuporte != null)
                {
                     return new Resposta<string>()
                     {
                         Status = true,
                         Dados  = senhaSuporte
                     };
                }
                else return null;
            } catch (Exception e)
            {
                return new Resposta<string>(
                    "Erro ao validar senha de suporte, tente novamente mais tarde ou entre em contato com o suporte!", 
                    $"AuthRepository/ValidarSenhaSuporte: {e.Message}"
                );
            }
        }
    }
}
