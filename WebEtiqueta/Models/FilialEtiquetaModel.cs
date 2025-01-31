using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
    public class FilialEtiquetaModel
    {
        //      CAMPOS.     //
        [Key]
        [Column("FILIAL_ETIQUETA_ID")]
        public int Id { get; set; }

        [Required]
        [Column("FILIAL_ID")]
        public int FilialId { get; set; }
        
        [Required]
        [Column("ETIQUETA_ID")]
        public int EtiquetaId { get; set; }
        //     /CAMPOS.     //

        //      RELACIONAMENTOS.     //
        public FilialModel Filial { get; set; }
        public EtiquetaModel Etiqueta { get; set; }
        //     /RELACIONAMENTOS.     //
    }
}
