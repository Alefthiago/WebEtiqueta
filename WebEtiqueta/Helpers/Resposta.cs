namespace WebEtiqueta.Helpers
{
    public class Resposta<T>
    {
        public bool status { get; set; }
        public string mensagem { get; set; }
        public string logSuporte { get; set; }
        public T dados { get; set; }

        public Resposta (bool status, string mensagem, T dados = default, string logSuporte = null)
        {
            this.status = status;
            this.mensagem = mensagem;
            this.dados = dados;
            this.logSuporte = logSuporte;
        }
    }
}
