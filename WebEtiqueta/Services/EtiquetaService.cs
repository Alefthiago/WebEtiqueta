using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Repositorys;

namespace WebEtiqueta.Services
{
    public class EtiquetaService
    {
        private readonly EtiquetaRepository _etiquetaRepository;
        public EtiquetaService(EtiquetaRepository etiquetaRepository)
        {
            _etiquetaRepository = etiquetaRepository;
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
