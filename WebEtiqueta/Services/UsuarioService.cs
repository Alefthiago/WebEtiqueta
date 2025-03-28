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

        public async Task<Resposta<NivelAcessoModel>> PegarNivelAcessoPorUsuario(string usuario, string empresa)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(empresa))
                    return new Resposta<NivelAcessoModel>("Usuário ou empresa não informados!");

                Resposta<NivelAcessoModel>? nivelAcesso = await _usuarioRepository.PegarNivelAcessoPorUsuario(usuario, empresa);
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
