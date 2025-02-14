using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
    [Table("USUARIO_FILIAL")]
    public class UsuarioFilialModel
    {
        [Required]
        [Column("USUARIO_ID")]
        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }

        [Required]
        [Column("FILIAL_ID")]
        public int FilialId { get; set; }
        public FilialModel Filial { get; set; }
    }
}
