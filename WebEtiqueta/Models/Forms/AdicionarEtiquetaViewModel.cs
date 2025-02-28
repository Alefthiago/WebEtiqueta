using System.ComponentModel.DataAnnotations;

namespace WebEtiqueta.Models.Forms
{
    public class AdicionarEtiquetaViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, ErrorMessage = "Nome pode ter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Modelo é obrigatório")]
        [StringLength(50, ErrorMessage = "Modelo pode ter no máximo 50 caracteres")]
        public string Modelo { get; set; }
        
        public string Impressora { get; set; }

        [Required(ErrorMessage = "Número de colunas é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Número de colunas deve ser maior que zero")]
        public int Colunas { get; set; }

        [Required(ErrorMessage = "Número de linhas é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Número de linhas deve ser maior que zero")]
        public int Linhas { get; set; }

        [Required(ErrorMessage = "Largura é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "Largura deve ser maior que zero")]
        public int Largura { get; set; }

        [Required(ErrorMessage = "Altura é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "Altura deve ser maior que zero")]
        public int Altura { get; set; }
    }
}
