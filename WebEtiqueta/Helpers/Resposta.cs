namespace WebEtiqueta.Helpers
{
    public class Resposta<T>
    {
        public bool status { get; set; }
        public string mensagem { get; set; }
        public T dados { get; set; }

        public Resposta (bool status, string mensagem, T dados = default)
        {
            this.status = status;
            this.mensagem = mensagem;
            this.dados = dados;
        }
    }
}
