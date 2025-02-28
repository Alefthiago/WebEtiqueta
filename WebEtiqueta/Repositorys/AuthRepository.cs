using WebEtiqueta.Helpers;
using WebEtiqueta.Models;

namespace WebEtiqueta.Repositorys
{
    public class AuthRepository
    {
        private readonly Contexto _contexto;
        private readonly IConfiguration _configuration;
        public AuthRepository(Contexto contexto, IConfiguration configuration)
        {
            _contexto = contexto;
            _configuration = configuration;
        }
        public Resposta<string>? SenhaSuporte(string senha)
        {
            try
            {
                //string? senhaSuporte = _configuration.GetValue<string>("Suprote:SenhaSuporte");
                string? senhaSuporte = _configuration.GetSection("Suporte:SenhaSuporte").Value;
                // Console.WriteLine(senhaSuporte);
                if (!string.IsNullOrWhiteSpace(senhaSuporte) && senhaSuporte != null)
                {
                     return new Resposta<string>()
                     {
                         Status = true,
                         Dados  = senhaSuporte
                     };
                }
                else return null;
            } catch (Exception e)
            {
                return new Resposta<string>(
                    "Erro ao validar senha de suporte, tente novamente mais tarde ou entre em contato com o suporte!", 
                    $"AuthRepository/ValidarSenhaSuporte: {e.Message}"
                );
            }
        }
    }
}
