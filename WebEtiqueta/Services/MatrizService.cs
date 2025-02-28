using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Repositorys;

namespace WebEtiqueta.Services
{
    public class MatrizService
    {
        public readonly MatrizRepository _matrizRepository;

        public MatrizService(MatrizRepository matrizRepository)
        {
            _matrizRepository = matrizRepository;
        }

        public async Task<Resposta<MatrizModel>> PegarMatrizPorCnpjCpf(string cnpjCpf)
        {
            if (string.IsNullOrWhiteSpace(cnpjCpf))
                return new Resposta<MatrizModel>("CNPJ/CPF é obrigatório");

            try
            {
                Resposta<MatrizModel>? matriz = await _matrizRepository.PegarMatrizPorCnpjCpf(cnpjCpf);
                if (matriz == null)
                    return new Resposta<MatrizModel>("Matriz não encontrada");
                else
                    return matriz;
            }
            catch (Exception e)
            {
                return new Resposta<MatrizModel>(
                    "Erro ao buscar matriz, tente novamente mais tarde ou entre em contato com o suporte!",
                    $"MatrizService/PegarMatrizPorCnpjCpf: {e.Message}"
                );
            }
        }
    }
}
