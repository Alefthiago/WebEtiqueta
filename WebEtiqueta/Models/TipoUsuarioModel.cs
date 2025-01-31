using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
    public class TipoUsuarioModel
    {
        //      CAMPOS.     //
        [Key]
        [Column("TIPO_USUARIO_ID")]
        public int Id { get; set; }

        [Required]
        [Column("TIPO_USUARIO_NIVEL_ACESSO_ID")]
        public int NivelAcessoId { get; set; }
        //     /CAMPOS.     //

        //      RELACIONAMENTOS.     //
        public NivelAcessoModel NivelAcesso { get; set; }
        //     /RELACIONAMENTOS.     //
    }
}
