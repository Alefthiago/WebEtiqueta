using Microsoft.EntityFrameworkCore;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Models.Forms;

namespace WebEtiqueta.Repositorys
{
    public class EtiquetaRepository
    {
        private readonly Contexto _contexto;

        public EtiquetaRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Resposta<bool>?> Adicionar(AdicionarEtiquetaViewModel form, EmpresaModel empresa)
        {
            using (var transaction = await _contexto.Database.BeginTransactionAsync())
            {
                try
                {
                    var etiqueta = new EtiquetaModel()
                    {
                        Nome            = form.Nome.ToLower(),
                        Colunas         = form.Colunas,
                        Linhas          = form.Linhas,
                        Modelo          = form.Modelo,
                        Largura         = form.Largura,
                        Altura          = form.Altura,
                        EspacoX         = 0,
                        EspacoY         = 0,
                        Tipo            = form.Tipo,
                        Eliminado       = false,
                        EliminadoData   = null,
                        EliminadoPor    = null,
                        EmpresaId        = empresa.Id
                    };
                
                    var resultado = await _contexto.Etiqueta.AddAsync(etiqueta);
                    await _contexto.SaveChangesAsync();
                    
                    int etiquetaId = etiqueta.Id;

                    await transaction.CommitAsync();
                    return new Resposta<bool>(true);
                } catch (Exception e)
                {
                    await transaction.RollbackAsync();
                    return new Resposta<bool>(
                        $"Erro inesperado ao adicionar etiqueta, tente novamente mais tarde ou entre em contato com nosso suporte",
                        $"EtiquetaRepository/Adicionar: {e.Message}"    
                    );
                }
            };
        }

        public async Task<Resposta<List<EtiquetaModel>>?> ListarEtiquetas(string empresa, int skip, int qtd, string search, int order, string orderable)
        {
            try
            {
                var query = from etiqueta in _contexto.Etiqueta
                            join emp in _contexto.Empresa on etiqueta.EmpresaId equals emp.Id
                            where emp.CnpjCpf == empresa && !etiqueta.Eliminado
                            select new EtiquetaModel
                            {
                                Id = etiqueta.Id,
                                Nome = etiqueta.Nome,
                                Modelo = etiqueta.Modelo,
                                Tipo = etiqueta.Tipo,
                            };

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(etiqueta => etiqueta.Nome.Contains(search) ||
                                                    etiqueta.Modelo.Contains(search) ||
                                                    etiqueta.Tipo.Contains(search));
                }

                switch (order)
                {
                    case 0:
                        query = orderable == "asc" ? query.OrderBy(etiqueta => etiqueta.Nome) : query.OrderByDescending(etiqueta => etiqueta.Nome);
                        break;
                    case 1:
                        query = orderable == "asc" ? query.OrderBy(etiqueta => etiqueta.Modelo) : query.OrderByDescending(etiqueta => etiqueta.Modelo);
                        break;
                    case 2:
                        query = orderable == "asc" ? query.OrderBy(etiqueta => etiqueta.Tipo) : query.OrderByDescending(etiqueta => etiqueta.Tipo);
                        break;
                    default:
                        query = query.OrderBy(etiqueta => etiqueta.Id);
                        break;
                }

                var etiquetas = await query
                                    .AsNoTracking()
                                    .Skip(skip)
                                    .Take(qtd)
                                    .ToListAsync();
                if (etiquetas == null)
                return null;

                return new Resposta<List<EtiquetaModel>>(etiquetas);
            }
            catch (Exception e)
            {
                return new Resposta<List<EtiquetaModel>>(
                    "Erro inesperado ao listar etiquetas, tente novamente mais tarde ou entre em contato com nosso suporte",
                    $"EtiquetaRepository/ListarEtiquetas: {e.Message}"
                );
            }
        }

        public async Task<Resposta<int>> QuantidadeEtiquetas(string empresa, string search)
        {
            try
            {
                var query = from etiqueta in _contexto.Etiqueta
                            join emp in _contexto.Empresa on etiqueta.EmpresaId equals emp.Id
                            where emp.CnpjCpf == empresa && !etiqueta.Eliminado
                            select etiqueta;

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(etiqueta => etiqueta.Nome.Contains(search) ||
                                                    etiqueta.Modelo.Contains(search) ||
                                                    etiqueta.Tipo.Contains(search));
                }

                var quantidade = await query
                                    .AsNoTracking()
                                    .CountAsync();
                //var quantidade = await (from etiqueta in _contexto.Etiqueta
                //                        join emp in _contexto.Empresa on etiqueta.EmpresaId equals emp.Id
                //                        where emp.CnpjCpf == empresa && !etiqueta.Eliminado
                //                        select etiqueta)
                //                        .AsNoTracking()
                //                        .CountAsync();

                return new Resposta<int>(quantidade);
            }
            catch (Exception e)
            {
                return new Resposta<int>(
                    "Erro inesperado ao listar etiquetas, tente novamente mais tarde ou entre em contato com nosso suporte",
                    $"EtiquetaRepository/QuantidadeEtiquetas: {e.Message}"
                );
            }
        }
    }
}
