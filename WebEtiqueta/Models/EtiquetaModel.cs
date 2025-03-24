using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
    [Table("ETIQUETA")]
    public class EtiquetaModel
    {
        //      CAMPOS.       //
        [Key]
        [Column("ETIQUETA_ID")]
        public int Id { get; set; }

        [Column("ETIQUETA_NOME")]
        [StringLength(50)]
        [Required]
        public string Nome { get; set; }

        [Column("ETIQUETA_COLUNAS")]
        [Required]
        public int Colunas { get; set; }

        [Column("ETIQUETA_LINHAS")]
        [Required]
        public int Linhas { get; set; }

        [Column("ETIQUETA_MODELO")]
        [StringLength(50)]
        [Required]
        public string Modelo { get; set; }

        [Column("ETIQUETA_LARGURA")]
        [Required]
        public int Largura { get; set; }

        [Column("ETIQUETA_ALTURA")]
        [Required]
        public int Altura { get; set; }

        [Column("ETIQUETA_ESPACOX")]
        [Required]
        public int EspacoX { get; set; }

        [Column("ETIQUETA_ESPACOY")]
        [Required]
        public int EspacoY { get; set; }

        [Column("ETIQUETA_TIPO")]
        [StringLength(50)]
        [Required]
        public string Tipo { get; set; }

        [Column("ETIQUETA_ELIMINADO")]
        [Required]
        public bool Eliminado { get; set; }

        [Column("ETIQUETA_ELIMINADO_DATA")]
        public DateTime? EliminadoData { get; set; }
        //     /CAMPOS.       //

        //      RELACIONAMENTOS.       //
        [Column("ETIQUETA_ELIMINADO_POR")]
        public int? EliminadoPor { get; set; }
        public UsuarioModel? Eliminador { get; set; }
        
        [Required]
        [Column("ETIQUETA_MATRIZ_ID")]
        public int MatrizId { get; set; }
        public MatrizModel Matriz { get; set; }
        public ICollection<FilialEtiquetaModel> Filiais { get; set; }
        //      RELACIONAMENTOS.       //
    }
}