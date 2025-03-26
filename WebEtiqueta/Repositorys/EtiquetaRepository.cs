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

        public async Task<Resposta<bool>?> Adicionar(AdicionarEtiquetaViewModel form, MatrizModel matriz)
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
                        MatrizId        = matriz.Id
                    };
                
                    var resultado = await _contexto.Etiqueta.AddAsync(etiqueta);
                    await _contexto.SaveChangesAsync();
                    
                    int etiquetaId = etiqueta.Id;

                    var filiais = await _contexto.Filial
                        .FromSqlRaw(@"
                            SELECT * 
                            FROM ""FILIAL"" 
                            WHERE ""FILIAL_MATRIZ_ID"" = @p0",
                        matriz.Id)
                        .ToListAsync();

                    if(filiais.Count > 0)
                    {
                        foreach (var filial in filiais)
                        {
                            await _contexto.FilialEtiqueta.AddAsync(new FilialEtiquetaModel()
                            {
                                FilialId    = filial.Id,
                                EtiquetaId  = etiquetaId,
                                MatrizId    = matriz.Id,
                                Disponivel  = true,
                            });
                        }
                    }

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

        public async Task<Resposta<List<EtiquetaModel>>> ListarEtiquetas(Dictionary<string, string> dados)
        {
            try
            {
                int matrizId = int.Parse(dados["MatrizId"]);
                int usuarioId = int.Parse(dados["UsuarioId"]);

                var etiquetas = await _contexto.Etiqueta
                    .FromSqlRaw(@"
                        SELECT e.*
                        FROM ""ETIQUETA"" e
                        JOIN ""FILIAL_ETIQUETA"" fe ON e.""ETIQUETA_ID"" = fe.""ETIQUETA_ID""
                        JOIN ""FILIAL"" f ON fe.""FILIAL_ID"" = f.""FILIAL_ID""
                        JOIN ""USUARIO_FILIAL"" uf ON f.""FILIAL_ID"" = uf.""FILIAL_ID""
                        WHERE e.""ETIQUETA_MATRIZ_ID"" = @p0
                            AND uf.""USUARIO_ID"" = @p1
                            AND fe.""DISPONIVEL"" = TRUE
                        LIMIT 10",
                        matrizId, usuarioId)
                    .ToListAsync();

                return new Resposta<List<EtiquetaModel>>(
                    //status: true,
                    mensagem: "Etiquetas listadas com sucesso",
                    dados: etiquetas
                );
            }
            catch (Exception e)
            {
                return new Resposta<List<EtiquetaModel>>(
                    //status: false,
                    mensagem: "Erro inesperado ao listar etiquetas, tente novamente mais tarde ou entre em contato com nosso suporte",
                    logSuporte: e.Message
                );
            }
        }

    }
}
