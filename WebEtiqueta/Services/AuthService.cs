using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
            {
                return new Resposta<MatrizModel>("CNPJ/CPF é obrigatório");
            }

            try
            {
                Resposta<MatrizModel>? matriz = await _authRepoistory.PegarMatrizPorCnpjCpf(cnpjCpf);
                if(matriz == null)
                {
                    return new Resposta<MatrizModel>("Matriz não encontrada");
                }
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
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(cnpjCpf))
            {
                return new Resposta<UsuarioModel>("Todos os dados são obrigatórios");
            }

            try
            {
                Resposta<UsuarioModel>? consultaUsuario = await _authRepoistory.PegarUsuarioPorLoginCnpjCpf(login, cnpjCpf);
                if (consultaUsuario == null) return new Resposta<UsuarioModel>("Dados Inválidos"); // Se o usuario não for encontrado
                else if (!consultaUsuario.Status) return consultaUsuario; // Se houver erro na consulta

                if(!ComprarSenhaLogin(consultaUsuario.Dados, senha)) return new Resposta<UsuarioModel>("Dados Inválidos");

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

        public Resposta<String> GerarJwtToken(UsuarioModel usuario)
        {
            try
            {
                if(usuario == null)
                {
                    return new Resposta<string>("Informe os dados do Usuário");
                }
                List<Claim> claims = new List<Claim>
                {
                    new Claim("Usuario", Convert.ToString(usuario.Login)),
                    new Claim("Matriz", Convert.ToString(usuario.Matriz.CnpjCpf))
                };

                string? secretKey = _config.GetSection("JwtSettings:SecretKey").Value;
                if (string.IsNullOrWhiteSpace(secretKey)) return new Resposta<string>("Chave de segurança não configurada");

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return new Resposta<string>()
                {
                    Status      = true,
                    Dados       = jwt,
                    Mensagem    = "Token gerado com sucesso"
                };
            }
            catch (Exception e)
            {
                return new Resposta<string>(mensagem: "Erro ao gerar token, tente novamente mais tarde ou entre em contato com nosso suporte", logSuporte: e.Message);
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

                return new Resposta<bool>(senhaSuporte.Dados == senha);
            } catch (Exception e)
            {
                return new Resposta<bool>(
                    "Erro ao validar senha de suporte, tente novamente mais tarde ou entre em contato com o suporte!", 
                    $"AuthService/ValidarSenhaSuporte: {e.Message}"
                );
            }
        }

        private bool ComprarSenhaLogin(UsuarioModel usuario, string senha)
        {
            var hasher = new PasswordHasher<string>();
            var senhaValida = hasher.VerifyHashedPassword(usuario.Login, usuario.Senha, senha);

            if (senhaValida == PasswordVerificationResult.Success)
            {
                return true;
            }

            return false;
        }
    }
}