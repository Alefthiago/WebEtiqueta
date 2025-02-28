using Microsoft.EntityFrameworkCore;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;

namespace WebEtiqueta.Repositorys
{
    public class MatrizRepository
    {
        private readonly Contexto _contexto;
        
        public MatrizRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Resposta<MatrizModel>?> PegarMatrizPorCnpjCpf(string cnpjCpf)
        {
            try
            {
                var resultado = await _contexto.Matriz
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.CnpjCpf == cnpjCpf);
                if (resultado != null)
                {
                    if (!string.IsNullOrWhiteSpace(resultado.Nome) && !string.IsNullOrWhiteSpace(resultado.CnpjCpf))
                    {
                        return new Resposta<MatrizModel>(resultado);
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                return new Resposta<MatrizModel>(
                    "Erro ao buscar matriz, tente novamente mais tarde ou entre em contato com o suporte!",
                    $"MatrizRepository/PegarMatrizPorCnpjCpf: {e.Message}"
                );
            }
        }
    }
}
