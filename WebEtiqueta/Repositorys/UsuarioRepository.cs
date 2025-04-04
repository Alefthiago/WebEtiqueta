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
