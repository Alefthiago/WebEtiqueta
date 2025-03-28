using Microsoft.EntityFrameworkCore;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;

namespace WebEtiqueta.Repositorys
{
    public class EmpresaRepository
    {
        private readonly Contexto _contexto;
        
        public EmpresaRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Resposta<EmpresaModel>?> PegarEmpresaPorCnpjCpf(string cnpjCpf)
        {
            try
            {
                var resultado = await _contexto.Empresa
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.CnpjCpf == cnpjCpf);
                if (resultado != null)
                {
                    if (!string.IsNullOrWhiteSpace(resultado.Nome) && !string.IsNullOrWhiteSpace(resultado.CnpjCpf))
                        return new Resposta<EmpresaModel>(resultado);
                }

                return null;
            }
            catch (Exception e)
            {
                return new Resposta<EmpresaModel>(
                    "Erro ao buscar Empresa, tente novamente mais tarde ou entre em contato com o suporte!",
                    $"EmpresaRepository/PegarEmpresaPorCnpjCpf: {e.Message}"
                );
            }
        }
    }
}
