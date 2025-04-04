using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Repositorys;

namespace WebEtiqueta.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private readonly AuthRepository _authRepoistory;
        private readonly EmpresaRepository _empresaRepository;
        private readonly UsuarioRepository _usuarioRepository;

        public AuthService(IConfiguration config, AuthRepository authRepository, EmpresaRepository empresaRepository, UsuarioRepository usuarioRepository)
        {
            _config             = config;
            _authRepoistory     = authRepository;
            _empresaRepository  = empresaRepository;
            _usuarioRepository  = usuarioRepository;
        }

        public async Task<Resposta<UsuarioModel>> ValidarLogin(string login, string senha, string cnpjCpf)
        {
            try
            {
                if(!Util.ValidaDocumento(cnpjCpf))
                    return new Resposta<UsuarioModel>("CNPJ/CPF inválido");
            
                Resposta<UsuarioModel>? consultaUsuario;
                if(login == "suporte")
                {
                    consultaUsuario = await _authRepoistory.PegarUsuarioSuporteLogin(login, cnpjCpf);
                    if(consultaUsuario == null) return new Resposta<UsuarioModel>("Não foi possível recuperar os dados do suporte, verifique as configurações da aplicação");
                } else
                {
                    consultaUsuario = await _authRepoistory.LoginUsuarioCnpjCpfLogin(login, cnpjCpf);
                    if (consultaUsuario == null) return new Resposta<UsuarioModel>("Dados inválidos, verifique os campos");
                }

                if (!consultaUsuario.Status)
                {
                    return new Resposta<UsuarioModel>(
                        consultaUsuario.Mensagem ?? "Não foi possível carregar os dados do suporte",
                        consultaUsuario.LogSuporte
                    );
                }
                if(consultaUsuario.Dados == null || consultaUsuario.Dados == default)
                    return new Resposta<UsuarioModel>("Dados inválidos, verifique os campos");
                
                if(!Util.CompararSenha(consultaUsuario.Dados, senha))
                    return new Resposta<UsuarioModel>("Dados inválidos, verifique os campos");

                return new Resposta<UsuarioModel>(consultaUsuario.Dados);
            }
            catch (Exception e)
            {
                return new Resposta<UsuarioModel>(
                    "Erro ao autenticar usuário, tente novamente mais tarde ou entre em contato com o suporte",
                    $"AuthService/ValidarLogin: {e.Message}"
                );
            }
        }

        public async Task<Resposta<bool>> ValidarSenhaSuporte(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                return new Resposta<bool>("Senha de suporte é obrigatória");
            }
            try
            {
                Resposta<UsuarioModel>? usuarioSuporte = await _authRepoistory.PegarUsuarioSuporte();
                if (!usuarioSuporte.Status)
                {
                    return new Resposta<bool>(
                        usuarioSuporte.Mensagem ?? "Não foi possível carregar os dados do suporte",
                        usuarioSuporte.LogSuporte
                    );
                }

                return Util.CompararSenha(usuarioSuporte.Dados, senha)
                    ? new Resposta<bool>(true)
                    : new Resposta<bool>("Senha inválida");
            }
            catch (Exception e)
            {
                return new Resposta<bool>(
                    "Erro ao validar senha de suporte, tente novamente mais tarde ou entre em contato com o suporte!", 
                    $"AuthService/ValidarSenhaSuporte: {e.Message}"
                );
            }
        }
    }
}