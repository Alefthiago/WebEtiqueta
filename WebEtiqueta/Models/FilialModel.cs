using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebEtiqueta.Models;

namespace WebEtiqueta.Models
{
    [Table("FILIAL")]
    public class FilialModel
    {
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
        [Column("FILIAL_ELIMINADO")]
        public bool Eliminado { get; set; }

        [Column("FILIAL_ELIMINADO_DATA")]
        public DateTime? EliminadoData { get; set; }

        //      RELACIONAMENTOS.     //
        [Column("FILIAL_ELIMINADO_POR")]
        public int? EliminadoPor { get; set; }
        public UsuarioModel? Eliminador { get; set; }

        [Required]
        [Column("FILIAL_MATRIZ_ID")]
        public int MatrizId { get; set; }
        public MatrizModel Matriz { get; set; }

        public ICollection<UsuarioFilialModel> Usuarios { get; set; }

        public ICollection<FilialEtiquetaModel> Etiquetas { get; set; }
        //      /RELACIONAMENTOS.     //
    }
}
