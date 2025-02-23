namespace WebEtiqueta.Helpers
{
    public class Resposta<T>
    {
        public bool Status { get; set; }
        public string? Mensagem { get; set; }
        public string? LogSuporte { get; set; }
        public T? Dados { get; set; }
        public Resposta()
        {
            Status = false;
            Mensagem = null;
            LogSuporte = null;
            Dados = default;
        }
        // ✅ Construtor para sucesso
        public Resposta(T dados, string mensagem = "Operação realizada com sucesso")
        {
            Status      = true;
            Mensagem    = mensagem;
            LogSuporte  = null;
            Dados       = dados;
        }
        // ✅ Construtor para erro
        public Resposta(string mensagem, string? logSuporte = null)
        {
            Status      = false;
            Mensagem    = mensagem;
            LogSuporte  = logSuporte;
            Dados       = default;
        }
    }
}