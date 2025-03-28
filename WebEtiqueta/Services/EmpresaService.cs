using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Repositorys;

namespace WebEtiqueta.Services
{
    public class EmpresaService
    {
        public readonly EmpresaRepository _EmpresaRepository;

        public EmpresaService(EmpresaRepository EmpresaRepository)
        {
            _EmpresaRepository = EmpresaRepository;
        }

        public async Task<Resposta<EmpresaModel>> PegarEmpresaPorCnpjCpf(string cnpjCpf)
        {
            if (string.IsNullOrWhiteSpace(cnpjCpf))
                return new Resposta<EmpresaModel>("CNPJ/CPF é obrigatório");

            try
            {
                Resposta<EmpresaModel>? Empresa = await _EmpresaRepository.PegarEmpresaPorCnpjCpf(cnpjCpf);
                if (Empresa == null)
                    return new Resposta<EmpresaModel>("Empresa não encontrada");
                else
                    return Empresa;
            }
            catch (Exception e)
            {
                return new Resposta<EmpresaModel>(
                    "Erro ao buscar Empresa, tente novamente mais tarde ou entre em contato com o suporte!",
                    $"EmpresaService/PegarEmpresaPorCnpjCpf: {e.Message}"
                );
            }
        }
    }
}
