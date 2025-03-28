using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Repositorys;
using WebEtiqueta.Models.Forms;

namespace WebEtiqueta.Services
{
    public class EtiquetaService
    {
        private readonly EtiquetaRepository _etiquetaRepository;
        private readonly EmpresaRepository _empresaRepository;
        public EtiquetaService(EtiquetaRepository etiquetaRepository, EmpresaRepository empresaRepository)
        {
            _etiquetaRepository = etiquetaRepository;
            _empresaRepository = empresaRepository;
        }

        public async Task<Resposta<bool>> AdicionarEtiqueta (AdicionarEtiquetaViewModel form, string empresa)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(empresa))
                    return new Resposta<bool>("Empresa não encontrada");

                Resposta<EmpresaModel>? consultaEmpresa = await _empresaRepository.PegarEmpresaPorCnpjCpf(empresa);
                if (consultaEmpresa == null)
                    return new Resposta<bool>("Empresa não encontrada");
                else if (!consultaEmpresa.Status)
                    return new Resposta<bool>(consultaEmpresa.Mensagem ?? "Não foi possível carregar os dados da Empresa", consultaEmpresa.LogSuporte);

                Resposta<bool>? etiqueta = await _etiquetaRepository.Adicionar(form, consultaEmpresa.Dados);

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

        public async Task<Resposta<List<EtiquetaModel>>> ListarEtiquetas(string empresa, int skip, int qtd)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(empresa))
                    return new Resposta<List<EtiquetaModel>>("Empresa não encontrada, tente novamente");
                if (skip < 0 || qtd < 1 || qtd > 10)
                    return new Resposta<List<EtiquetaModel>>("Parâmetros inválidos, tente novamente");

                Resposta<List<EtiquetaModel>>? etiquetas = await _etiquetaRepository.ListarEtiquetas(empresa, skip, qtd);
                if(etiquetas == null)
                    return new Resposta<List<EtiquetaModel>>("Etiquetas não encontradas");
                else if (!etiquetas.Status)
                    return new Resposta<List<EtiquetaModel>>(etiquetas.Mensagem ?? "Não foi possível listar as etiquetas", etiquetas.LogSuporte);

                return new Resposta<List<EtiquetaModel>>(etiquetas.Dados);
            }
            catch (Exception e)
            {
                return new Resposta<List<EtiquetaModel>>(
                    "Erro ao listar etiquetas, tente novamente mais tarde ou entre em contato com o suporte!",
                    $"EmpresaService/ListarEtiquetas: {e.Message}"
                );
            }
        }
    }
}
