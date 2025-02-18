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

        public async Task<Resposta<MatrizModel>> PegarMatrizPorCnpjCpf(string documento)
        {
            try
            {
                //if (!Regex.IsMatch(documento, @"^\d+$"))
                //{
                //    return new Resposta<MatrizModel>(
                //        status: false,
                //        mensagem: "CNPJ/CPF inválido, digite apenas números"
                //    );
                //}

                Resposta<MatrizModel> consulta = await _authRepoistory.PegarMatrizPorCnpjCpf(documento);
                
                return new Resposta<MatrizModel>(
                    status: consulta.status,
                    mensagem: consulta.mensagem,
                    dados: consulta.dados,
                    logSuporte: consulta.logSuporte
                );
            }
            catch (Exception e)
            {
                return new Resposta<MatrizModel>(
                    status: false,
                    mensagem: "Erro inesperado ao buscar matriz, tente novamente mais tarde ou entre em contato com nosso suporte",
                    logSuporte: $"AuthService/PegarMatriz: {e.Message}"
                );
            }
        }

        public Resposta<String> GerarJwtToken(UsuarioModel usuario)
        {
            try
            {
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

                return new Resposta<string>(
                    status: true,
                    mensagem: "Token gerado com sucesso",
                    dados: jwt
                );

            }
            catch (Exception e)
            {
                return new Resposta<string>(
                    status: false,
                    mensagem: "Erro ao gerar token, tente novamente mais tarde ou entre em contato com nosso suporte",
                    logSuporte: e.Message
                );
            }
        }

        public async Task<Resposta<UsuarioModel>> ValidarLogin(string login, string senha)
        {
            try
            {
                Resposta<UsuarioModel> consulta = await _authRepoistory.ValidarLogin(login, senha);
                if (!consulta.status)
                { 
                    return new Resposta<UsuarioModel>(
                        status: false,
                        mensagem: "Usuário ou senha inválidos!"
                    );
                }

                return new Resposta<UsuarioModel>(
                    status: true,
                    mensagem: "Usuário autenticado",
                    dados: consulta.dados
                );
            }
            catch (Exception e)
            {
                return new Resposta<UsuarioModel>(
                    status: false,
                    mensagem: "Erro ao autenticar usuário, tente novamente mais tarde ou entre em contato com o suporte!",
                    logSuporte: e.Message
                );
            }
        }
    }
}