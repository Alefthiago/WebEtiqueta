using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Repositorys;

namespace WebEtiqueta.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private readonly AuthRepository _authRepoistory;
        public AuthService(IConfiguration config, AuthRepository authRepository)
        {
            _config = config;
            _authRepoistory = authRepository;
        }

        public async Task<Resposta<MatrizModel>> PegarMatrizPorCnpjCpf(string cnpjCpf)
        {
            if(string.IsNullOrWhiteSpace(cnpjCpf))
                return new Resposta<MatrizModel>("CNPJ/CPF é obrigatório");

            try
            {
                Resposta<MatrizModel>? matriz = await _authRepoistory.PegarMatrizPorCnpjCpf(cnpjCpf);
                if(matriz == null)
                    return new Resposta<MatrizModel>("Matriz não encontrada");
                else
                    return matriz;
            }
            catch (Exception e)
            {
                return new Resposta<MatrizModel>(
                    "Erro ao buscar matriz, tente novamente mais tarde ou entre em contato com o suporte!", 
                    $"AuthService/PegarMatrizPorCnpjCpf: {e.Message}"
                );
            }
        }

        public async Task<Resposta<UsuarioModel>> ValidarLogin(string login, string senha, string cnpjCpf)
        {
            try
            {
                Resposta<UsuarioModel>? consultaUsuario;

                string? loginSuporte = _config.GetSection("Suporte:LoginSuporte").Value;
                string? senhaSuporte = _config.GetSection("Suporte:SenhaSuporte").Value;
                if(string.IsNullOrWhiteSpace(loginSuporte) || string.IsNullOrWhiteSpace(senhaSuporte)) 
                    return new Resposta<UsuarioModel>("Dados de suporte não configurados");

                if (loginSuporte == login)
                {
                    Resposta<MatrizModel>? consultaMatriz = await _authRepoistory.PegarMatrizPorCnpjCpf(cnpjCpf);
                    if (consultaMatriz == null) 
                        return new Resposta<UsuarioModel>("Matriz não encontrada");
                    else if (!consultaMatriz.Status) 
                        return new Resposta<UsuarioModel>(consultaMatriz.Mensagem ?? "Não foi possível carregar os dados da matriz", consultaMatriz.LogSuporte);

                    UsuarioModel usuarioSuporte = new UsuarioModel()
                    {
                        Login   = loginSuporte,
                        Nome    = loginSuporte,
                        Senha   = senhaSuporte,
                        Matriz  = new MatrizModel()
                        {
                            CnpjCpf = cnpjCpf
                        }
                    };

                    if (!Util.CompararSenha(usuarioSuporte, senha)) 
                        return new Resposta<UsuarioModel>("Dados Inválidos");

                    consultaUsuario = new Resposta<UsuarioModel>(usuarioSuporte);
                }
                else
                {
                    consultaUsuario = await _authRepoistory.PegarUsuarioPorLoginCnpjCpf(login, cnpjCpf);
                    if (consultaUsuario == null) // consulta sem resultado
                        return new Resposta<UsuarioModel>("Dados Inválidos");
                    else if (!consultaUsuario.Status) // erro na consulta
                        return consultaUsuario;

                    if (!Util.CompararSenha(consultaUsuario.Dados, senha))
                        return new Resposta<UsuarioModel>("Dados Inválidos");
                }

                return consultaUsuario;
            }
            catch (Exception e)
            {
                return new Resposta<UsuarioModel>(
                    "Erro ao autenticar usuário, tente novamente mais tarde ou entre em contato com o suporte",
                    $"AuthService/ValidarLogin: {e.Message}"
                );
            }
        }

        public Resposta<bool> ValidarSenhaSuporte(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                return new Resposta<bool>("Senha de suporte é obrigatória");
            }
            try
            {
                Resposta<string>? senhaSuporte = _authRepoistory.SenhaSuporte(senha);
                if (senhaSuporte == null) return new Resposta<bool>("Não foi possível recuperar a senha do suporte");
                else if (!senhaSuporte.Status)
                {
                    return new Resposta<bool>(
                        senhaSuporte.Mensagem ?? "Não foi possível carregar os dados da configuração",
                        senhaSuporte.LogSuporte
                    );
                }

                UsuarioModel usuario = new UsuarioModel()
                {
                    Login = _config.GetSection("Suporte:LoginSuporte").Value,
                    Senha = senhaSuporte.Dados,
                };

                if (!Util.CompararSenha(usuario, senha)) return new Resposta<bool>("Senha inválida");

                return new Resposta<bool>(true);
            } catch (Exception e)
            {
                return new Resposta<bool>(
                    "Erro ao validar senha de suporte, tente novamente mais tarde ou entre em contato com o suporte!", 
                    $"AuthService/ValidarSenhaSuporte: {e.Message}"
                );
            }
        }
    }
}