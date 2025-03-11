using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Repositorys;

namespace WebEtiqueta.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Resposta<NivelAcessoModel>> PegarNivelAcessoPorUsuario(string usuario, string matriz)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(matriz))
                    return new Resposta<NivelAcessoModel>("Usuário ou matriz não informados!");

                Resposta<NivelAcessoModel>? nivelAcesso = await _usuarioRepository.PegarNivelAcessoPorUsuario(usuario, matriz);
                if(nivelAcesso == null)
                    return new Resposta<NivelAcessoModel>("Erro ao buscar nível de acesso!");
                else if (!nivelAcesso.Status)
                    return new Resposta<NivelAcessoModel>(nivelAcesso.Mensagem ?? "Não foi possível carregar os dados", nivelAcesso.LogSuporte);

                return new Resposta<NivelAcessoModel>(nivelAcesso.Dados);
            } catch (Exception e)
            {
                return new Resposta<NivelAcessoModel>(
                    $"Erro ao buscar nível de acesso!",
                    $"UsuarioService/PegarNivelAcessoPorUsuario: {e.Message}"
                );
            }
        }
    }
}
