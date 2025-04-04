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

        public async Task<Resposta<UsuarioModel>?> PegarUsuarioSuporte()
        {
            try
            {
                var resultado = await _contexto.Usuario
                    .AsNoTracking()
                    .FirstOrDefaultAsync(usuario => usuario.Id == 1);

                return resultado != null
                    ? new Resposta<UsuarioModel>(resultado)
                    : new Resposta<UsuarioModel>("Usuário suporte não encontrado");
            }
            catch (Exception e)
            {
                return new Resposta<UsuarioModel>(
                    "Erro ao buscar usuário suporte, tente novamente mais tarde ou entre em contato com o suporte!",
                    $"AuthRepository/PegarUsuarioSuporte: {e.Message}"
                );

            }
        }
                public async Task<Resposta<UsuarioModel>?> PegarUsuarioSuporteLogin(string login, string cnpjCpf)
        {
            try
            {
                var resultado = await _contexto.Usuario
                    .AsNoTracking()
                    .FirstOrDefaultAsync(usuario => usuario.Id == 1);

                if (resultado != null)
                {
                    var empresa = await _contexto.Empresa
                        .AsNoTracking()
                        .FirstOrDefaultAsync(empresa => empresa.CnpjCpf == cnpjCpf);

                    if (empresa == null)
                        return new Resposta<UsuarioModel>("CNPJ/CPF inválido");
                    resultado.Empresa = empresa;

                    var nivelAcesso = await _contexto.NivelAcesso
                        .AsNoTracking()
                        .FirstOrDefaultAsync(nivel => nivel.Id == resultado.NivelAcessoId);

                    if (nivelAcesso == null)
                        return new Resposta<UsuarioModel>("Nivel de acesso do suporte não configurado");

                    resultado.NivelAcesso = nivelAcesso;
                    return new Resposta<UsuarioModel>(resultado);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                return new Resposta<UsuarioModel>(
                    "Erro ao autenticar usuário, tente novamente mais tarde ou entre em contato com o suporte!",
                    $"AuthRepository/LoginSuporte: {e.Message}"
                );
            }
        }

        public async Task<Resposta<UsuarioModel>?> LoginUsuarioCnpjCpfLogin(string loginUsuario, string cnpjCpf)
        {
            try
            {
                var resultado = await _contexto.Usuario
                .AsNoTracking()
                    .Join(
                        _contexto.Empresa,
                        usuario => usuario.EmpresaId,
                        empresa => empresa.Id,
                        (usuario, empresa) => new
                        {
                            usuario,
                            empresa
                        }
                    )
                    .Join(
                        _contexto.NivelAcesso,
                        usuarioEmpresa => usuarioEmpresa.usuario.NivelAcessoId,
                        nivelAcesso => nivelAcesso.Id,
                        (usuarioEmpresa, nivelAcesso) => new
                        {
                            usuarioEmpresa.usuario,
                            usuarioEmpresa.empresa,
                            nivelAcesso
                        }
                    )
                    .FirstOrDefaultAsync(resultado =>
                        resultado.usuario.Eliminado == false &&
                        resultado.empresa.CnpjCpf == cnpjCpf &&
                        resultado.usuario.Login == loginUsuario
                    );
                if (resultado != null)
                {
                    if (!string.IsNullOrWhiteSpace(resultado.usuario.Login) && !string.IsNullOrWhiteSpace(resultado.usuario.Senha))
                    {
                        UsuarioModel usuario = new UsuarioModel
                        {
                            Id          = resultado.usuario.Id,
                            Login       = resultado.usuario.Login,
                            Nome        = resultado.usuario.Nome,
                            Senha       = resultado.usuario.Senha,
                            Empresa     = new EmpresaModel { CnpjCpf = resultado.empresa.CnpjCpf },
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

        public Resposta<string>? SenhaSuporte(string senha)
        {
            try
            {
                //string? senhaSuporte = _configuration.GetValue<string>("Suprote:SenhaSuporte");
                string? senhaSuporte = _configuration.GetSection("Suporte:SenhaSuporte").Value;
                // Console.WriteLine(senhaSuporte);
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
