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
        
        public async Task<Resposta<MatrizModel>> PegarMatrizPorCnpjCpf(string documento)
        {
            try
            {
                var resultado = await _contexto.Matriz
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.CnpjCpf == documento);
                if(resultado != null)
                {
                    return new Resposta<MatrizModel>(resultado);
                }

                return new Resposta<MatrizModel>("Matriz não encontrada");
            } catch (Exception e)
            {
                return new Resposta<MatrizModel>("Erro ao buscar matriz, tente novamente mais tarde ou entre em contato com o suporte!", $"AuthRepository/PegarMatrizPorCnpjCpf: {e.Message}");
            }
        }

        public async Task<Resposta<UsuarioModel>> ValidarLogin(string login, string senha)
        {
            try
            {
                var resultado = await _contexto.Usuario
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Login == login);
                if (resultado != null && VerificarSenhaLogin(resultado, senha))
                {
                    return new Resposta<UsuarioModel>(resultado);
                }

                return new Resposta<UsuarioModel>("Usuário ou senha inválidos");
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

        public bool VerificarSenhaLogin(UsuarioModel usuario, string senha)
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
