using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Repositorys;

namespace WebEtiqueta.Services
{
    public class HomeService
    {
        private readonly EtiquetaRepository _etiquetaRepository;

        public HomeService(EtiquetaRepository etiquetaRepository)
        {
            _etiquetaRepository = etiquetaRepository;
        }

        public async Task<Resposta<List<EtiquetaModel>>> ListarEtiquetas(Dictionary<string, string> dados)
        {
            try
            {
                var etiquetas = await _etiquetaRepository.ListarEtiquetas(dados);
                if(etiquetas.status)
                {
                    return new Resposta<List<EtiquetaModel>>(
                        status: true,
                        mensagem: "Etiquetas listadas com sucesso",
                        dados: etiquetas.dados
                    );
                } else
                {
                    return new Resposta<List<EtiquetaModel>>(
                        status: false,
                        mensagem: etiquetas.mensagem,
                        logSuporte: etiquetas.logSuporte
                    );
                }
            } catch (Exception e)
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
