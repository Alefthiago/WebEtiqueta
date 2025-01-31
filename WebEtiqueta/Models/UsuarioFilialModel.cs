using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
    public class UsuarioFilialModel
    {
        //      CAMPOS.     //
        [Key]
        [Column("USUARIO_FILIAL_ID")]
        public int Id { get; set; }

        [Required]
        [Column("USUARIO_FILIAL_USUARIO_ID")]
        public int UsuarioId { get; set; }
        [Required]
        [Column("USUARIO_FILIAL_FILIAL_ID")]
        //     /CAMPOS.     //

        //      RELACIONAMENTOS.     //
        public int FilialId { get; set; }
        public UsuarioModel Usuario { get; set; }
        public FilialModel Filial { get; set; }
        //     /RELACIONAMENTOS.     //

    }
}
