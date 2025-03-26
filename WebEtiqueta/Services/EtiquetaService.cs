using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Repositorys;
using WebEtiqueta.Models.Forms;

namespace WebEtiqueta.Services
{
    public class EtiquetaService
    {
        private readonly EtiquetaRepository _etiquetaRepository;
        private readonly MatrizRepository _matrizRepository;
        public EtiquetaService(EtiquetaRepository etiquetaRepository, MatrizRepository matrizRepository)
        {
            _etiquetaRepository = etiquetaRepository;
            _matrizRepository = matrizRepository;
        }

        public async Task<Resposta<bool>> AdicionarEtiqueta (AdicionarEtiquetaViewModel form, string matriz)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(matriz))
                    return new Resposta<bool>("Matriz não encontrada");

                Resposta<MatrizModel>? consultaMatriz = await _matrizRepository.PegarMatrizPorCnpjCpf(matriz);
                if (consultaMatriz == null)
                    return new Resposta<bool>("Matriz não encontrada");
                else if (!consultaMatriz.Status)
                    return new Resposta<bool>(consultaMatriz.Mensagem ?? "Não foi possível carregar os dados da matriz", consultaMatriz.LogSuporte);

                Resposta<bool>? etiqueta = await _etiquetaRepository.Adicionar(form, consultaMatriz.Dados);

                if(etiqueta == null)
                    return new Resposta<bool>("Erro inesperado ao adicionar etiqueta, tente novamente mais tarde ou entre em contato com nosso suporte");
                else if (!etiqueta.Status)
                    return new Resposta<bool>(etiqueta.Mensagem ?? "Não foi possível adicionar a etiqueta", etiqueta.LogSuporte);

                return new Resposta<bool>(
                    true,
                    "Etiqueta adicionada com sucesso"
                );
            }
            catch (Exception e)
            {
                return new Resposta<bool>(
                    "Erro inesperado ao adicionar etiqueta, tente novamente mais tarde ou entre em contato com nosso suporte",
                    $"EtiquetaService/AdicionarEtiqueta: {e.Message}"
                );
            }
        }

        public async Task<Resposta<List<EtiquetaModel>>> ListarEtiquetas(Dictionary<string, string> dados)
        {
            try
            {
                var consulta = await _etiquetaRepository.ListarEtiquetas(dados);
                if (consulta.Status)
                {
                    return new Resposta<List<EtiquetaModel>>(
                        //status: true,
                        mensagem: "Etiquetas listadas com sucesso",
                        dados: consulta.Dados
                    );
                }
                else
                {
                    return new Resposta<List<EtiquetaModel>>(
                        //status: false,
                        mensagem: consulta.Mensagem,
                        logSuporte: consulta.LogSuporte
                    );
                }
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
