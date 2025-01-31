using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
    public class EtiquetaModel
    {
        //      CAMPOS.       //
        [Key]
        [Column("ETIQUETA_ID")]
        public int Id { get; set; }

        [Required]
        [Column("ETIQUETA_MATRIZ_ID")]
        public int MatrizId { get; set; }

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

        //[Column("ETIQUETA_IMPRESSORA")]
        //[StringLength(50)]
        //[Required]
        //public string Impressora { get; set; }

        [Column("ETIQUETA_ELIMINADO")]
        [Required]
        public bool Eliminado { get; set; }

        [Column("ETIQUETA_ELIMINADO_POR")]
        [ForeignKey("UsuarioId")]
        public int EliminadoPor { get; set; }

        [Column("ETIQUETA_ELIMINADO_DATA")]
        public DateTime EliminadoData { get; set; }

        [Column("ETIQUETA_CRIADO_POR")]
        [Required]
        public int CriadoPor { get; set; }

        [Column("ETIQUETA_CRIADO_DATA")]
        [Required]
        public DateTime CriadoData { get; set; }

        //     /CAMPOS.       //

        //      RELACIONAMENTOS.       //
        public UsuarioModel Criador { get; set; }
        public MatrizModel Matriz { get; set; }
        public List<FilialEtiquetaModel> FilialEtiquetas { get; set; }
        //      RELACIONAMENTOS.       //
    }
}