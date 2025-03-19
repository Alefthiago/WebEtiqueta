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

                string? nivelAcessoSession = session.GetString("NivelAcesso");
                if (string.IsNullOrWhiteSpace(nivelAcessoSession))
                {
                    return new Resposta<bool>("Nível de acesso não encontrado, faça o login novamente");
                }

                string? nivelAcessoIdSuporte = config.GetSection("Suporte:NivelAcessoId").Value;
                if (string.IsNullOrWhiteSpace(nivelAcessoIdSuporte))
                {
                    return new Resposta<bool>("Nível de acesso de suporte não configurado");
                }

                return new Resposta<bool>(true);
            }
            catch (Exception e)
            {
                return new Resposta<bool>(
                    "Erro ao validar nível de acesso, tente novamente mais tarde ou entre em contato com o suporte",
                    $"ValidacoesPadrao/ValidarNivelAcesso: {e.Message}"
                );
            }
        }
    }
}
