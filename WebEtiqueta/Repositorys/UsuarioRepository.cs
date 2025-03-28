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
        public async Task<Resposta<UsuarioModel>?> LoginUsuarioPorLoginCnpjCpf(string loginUsuario, string cnpjCpf)
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
                            Login   = resultado.usuario.Login,
                            Nome    = resultado.usuario.Nome,
                            Senha   = resultado.usuario.Senha,
                            Empresa  = new EmpresaModel { CnpjCpf = resultado.empresa.CnpjCpf},
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

        public async Task<Resposta<NivelAcessoModel>?> PegarNivelAcessoPorUsuario(string login, string empresa)
        {
            try
            {
                var resultado = await (from nivelAcesso in _contexto.NivelAcesso
                                join usuario in _contexto.Usuario
                                on nivelAcesso.Id equals usuario.NivelAcessoId
                                join empresaModel in _contexto.Empresa
                                on usuario.EmpresaId equals empresaModel.Id
                                where usuario.Login == login && empresaModel.CnpjCpf == empresa
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
