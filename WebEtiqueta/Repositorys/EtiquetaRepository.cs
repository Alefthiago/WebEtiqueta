using Microsoft.EntityFrameworkCore;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;

namespace WebEtiqueta.Repositorys
{
    public class EtiquetaRepository
    {
        private readonly Contexto _contexto;

        public EtiquetaRepository(Contexto contexto)
        {
            _contexto = contexto;
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
                    status: true,
                    mensagem: "Etiquetas listadas com sucesso",
                    dados: etiquetas
                );
            }
            catch (Exception e)
            {
                return new Resposta<List<EtiquetaModel>>(
                    status: false,
                    mensagem: "Erro inesperado ao listar etiquetas, tente novamente mais tarde ou entre em contato com nosso suporte",
                    logSuporte: e.Message
                );
            }
        }

    }
}
