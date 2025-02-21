namespace WebEtiqueta.Helpers
{
    public class Resposta<T>
    {
        public bool Status { get; set; }
        public bool Erro { get; set; }
        public string? Mensagem { get; set; }
        public string? LogSuporte { get; set; }
        public T? Dados { get; set; }
        public Resposta()
        {
            Status = false;
            Erro = false;
            Mensagem = null;
            LogSuporte = null;
            Dados = default;
        }
        // ✅ Construtor para sucesso
        public Resposta(T dados, string mensagem = "Operação realizada com sucesso")
        {
            Status      = true;
            Erro        = false;
            Mensagem    = mensagem;
            LogSuporte  = null;
            Dados       = dados;
        }
        // ✅ Construtor para consulta sem resultado
        public Resposta(string mensagem)
        {
            Status      = false;
            Erro        = false;
            Mensagem    = mensagem;
            LogSuporte  = null;
            Dados       = default;
        }
        // ✅ Construtor para erro
        public Resposta(string mensagem, string logSuporte)
        {
            Status      = false;
            Erro        = true;
            Mensagem    = mensagem;
            LogSuporte  = logSuporte;
            Dados       = default;
        }
    }
}