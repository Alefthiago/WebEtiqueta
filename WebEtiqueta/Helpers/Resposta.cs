namespace WebEtiqueta.Helpers
{
    public class Resposta<T>
    {
        public bool Status { get; set; }
        public string Mensagem { get; set; }
        public string LogSuporte { get; set; }
        public T Dados { get; set; }

        public Resposta() { }

        // ✅ Construtor para sucesso
        public Resposta(T dados, string mensagem = "Operação realizada com sucesso")
        {
            Status = true;
            Mensagem = mensagem;
            Dados = dados;
        }

        // ✅ Construtor para erro
        public Resposta(string mensagem, string logSuporte = "")
        {
            Status = false;
            Mensagem = mensagem;
            LogSuporte = logSuporte;
        }
    }
}
