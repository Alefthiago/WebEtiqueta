using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
    public class FilialModel
    {
        //      CAMPOS.     //
        [Key]
        [Column("FILIAL_ID")]
        public int Id { get; set; }

        [Required]
        [Column("FILIAL_NOME")]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required]
        [Column("FILIAL_CPNJ_CPF")]
        [StringLength(14)]
        public string CnpjCpf { get; set; }

        [Required]
        [Column("FILIAL_MATRIZ_ID")]
        public int MatrizId { get; set; }
        //     /CAMPOS.     //

        //      RELACIONAMENTOS.     //
        public MatrizModel Matriz { get; set; }
        public List<UsuarioFilialModel> UsuarioFilials { get; set; }
        public List<EtiquetaModel> Etiquetas { get; set; }
        //     /RELACIONAMENTOS.     //
    }
}
