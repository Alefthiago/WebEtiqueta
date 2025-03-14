using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using WebEtiqueta.Models;

namespace WebEtiqueta.Helpers
{
    public static class ValidacoesPadrao
    {
        public static Resposta<bool> ValidarNivelAcesso(HttpContext httpContext, IConfiguration config)
        {
            try
            {
                var session = httpContext.Session;
                var response = httpContext.Response;

                // Obtém o nível de acesso da sessão
                string? nivelAcessoSession = session.GetString("NivelAcesso");

                if (string.IsNullOrWhiteSpace(nivelAcessoSession))
                {
                    response.Cookies.Delete("AuthToken");
                    session.Clear();
                    return new Resposta<bool>
                    {
                        Status      = false,
                        Mensagem    = "Nível de acesso não encontrado, faça o login novamente."
                    };
                }

                // Obtém o nível de acesso do suporte a partir do appsettings.json
                string? nivelAcessoIdSuporte = config.GetSection("Suporte:NivelAcessoId").Value;
                if (string.IsNullOrWhiteSpace(nivelAcessoIdSuporte))
                {
                    return new Resposta<bool>
                    {
                        Status      = false,
                        Mensagem    = "Nível de acesso de suporte não configurado, entre em contato com o suporte."
                    };
                }

                return new Resposta<bool> { Status = true };
            }
            catch (Exception e)
            {
                return new Resposta<bool>
                {
                    Status = false,
                    Mensagem = "Erro ao validar nível de acesso: " + e.Message
                };
            }
        }
    }
}
