using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
    [Table("NIVEL_ACESSO")]
    public class NivelAcessoModel
    {
        //      CAMPOS.     //
        [Key]
        [Column("NIVEL_ACESSO_ID")]
        public int Id { get; set; }

        [Required]
        [Column("NIVEL_ACESSO_NOME")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [Column("NIVEL_ACESSO_ADICIONAR_USUARIO")]
        public bool AdicionarUsuario { get; set; }

        [Required]
        [Column("NIVEL_ACESSO_EDITAR_USUARIO")]
        public bool EditarUsuario { get; set; }

        [Required]
        [Column("NIVEL_ACESSO_EXCLUIR_USUARIO")]
        public bool ExcluirUsuario { get; set; }

        [Required]
        [Column("NIVEL_ACESSO_ADICIONAR_ETIQUETA")]
        public bool AdicionarEtiqueta { get; set; }

        [Required]
        [Column("NIVEL_ACESSO_EDITAR_ETIQUETA")]
        public bool EditarEtiqueta { get; set; }

        [Required]
        [Column("NIVEL_ACESSO_EXCLUIR_ETIQUETA")]
        public bool ExcluirEtiqueta { get; set; }
        //      CAMPOS.     //

        //      RELACIONAMENTOS.     //
        [Column("NIVEL_ACESSO_EMPRESA_ID")]
        public int EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }

        [Required]
        [Column("NIVEL_ACESSO_ELIMINADO")]
        public bool Eliminado { get; set; }

        [Column("NIVEL_ACESSO_ELIMINADO_DATA")]
        public DateTime? EliminadoData { get; set; }

        [Column("NIVEL_ACESSO_ELIMINADO_POR")]
        public int? EliminadoPor { get; set; }
        public UsuarioModel? Eliminador { get; set; }
        public ICollection<UsuarioModel> Usuarios { get; set; }
        //     /RELACIONAMENTOS.     //

    }
}
