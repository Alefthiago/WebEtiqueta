using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
    [Table("FILIAL_ETIQUETA")]
    public class FilialEtiquetaModel
    {
        [Required]
        [Column("DISPONIVEL")]
        public bool Disponivel { get; set; }

        [Required]
        [Column("FILIAL_ID")]
        public int FilialId { get; set; }
        public FilialModel Filial { get; set; }
        
        [Required]
        [Column("ETIQUETA_ID")]
        public int EtiquetaId { get; set; }
        public EtiquetaModel Etiqueta { get; set; }
    }
}
