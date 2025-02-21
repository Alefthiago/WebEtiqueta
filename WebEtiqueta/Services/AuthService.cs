using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
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
                return new Resposta<MatrizModel>("Erro ao buscar matriz, tente novamente mais tarde ou entre em contato com o suporte!", $"AuthService/PegarMatrizPorCnpjCpf: {e.Message}");
            }
        }

        public async Task<Resposta<UsuarioModel>> ValidarLogin(string login, string senha)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
            {
                return new Resposta<UsuarioModel>(mensagem: "Login e Senha são obrigatórios");
            }

            try
            {
                Resposta<UsuarioModel>? consultaUsuario = await _authRepoistory.ValidarLogin(login, senha);
                if (consultaUsuario == null)
                    return new Resposta<UsuarioModel>("Usuário não encontrado");
                else if (consultaUsuario.Erro)
                    return consultaUsuario;
                else
                {
                    bool loginValido = ComprarSenhaLogin(consultaUsuario.Dados, senha);
                    return loginValido ? consultaUsuario : new Resposta<UsuarioModel>("Senha inválida");
                }
            }
            catch (Exception e)
            {
                return new Resposta<UsuarioModel>("Erro ao autenticar usuário, tente novamente mais tarde ou entre em contato com o suporte", e.Message);
            }
        }

        public Resposta<String> GerarJwtToken(UsuarioModel usuario)
        {
            try
            {
                if(usuario == null)
                {
                    return new Resposta<string>("Informe os dados do Usuario");
                }
                List<Claim> claims = new List<Claim>
                {
                    new Claim("UsuarioId", Convert.ToString(usuario.Id)),
                    new Claim("MatrizId", Convert.ToString(usuario.MatrizId))
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("JwtSettings:SecretKey").Value));
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return new Resposta<string>(jwt, "Token gerado com sucesso");
            }
            catch (Exception e)
            {
                return new Resposta<string>(mensagem: "Erro ao gerar token, tente novamente mais tarde ou entre em contato com nosso suporte", logSuporte: e.Message);
            }
        }

        public Resposta<string> ValidarSenhaSuporte(string senha)
        {
            try
            {
                Resposta<string> senhaSuporte = _authRepoistory.ValidarSenhaSuporte(senha);

                if (!senhaSuporte.Status)
                {
                    return senhaSuporte;
                }

                if (senhaSuporte.Dados != senha)
                {
                    return new Resposta<string>("Senha invalida");
                }

                return new Resposta<string>("Senha validada com sucesso");

            } catch (Exception e)
            {
                return new Resposta<string>("Erro ao validar senha de suporte, tente novamente mais tarde ou entre em contato com o suporte!", $"AuthService/ValidarSenhaSuporte: {e.Message}");
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