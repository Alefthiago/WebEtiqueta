using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
    [Table("EMPRESA")]
    public class EmpresaModel
    {
        //      CAMPOS.     //
        [Key]
        [Column("EMPRESA_ID")]
        public int Id { get; set; }

        [Required]
        [Column("EMPRESA_NOME")]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required]
        [Column("EMPRESA_CNPJ_CPF")]
        [StringLength(14)]
        public string CnpjCpf { get; set; }
        //     /CAMPOS.     //

        //      RELACIONAMENTOS.     //
        public ICollection<UsuarioModel> Usuarios { get; set; }
        public ICollection<EtiquetaModel> Etiquetas { get; set; }
        public ICollection<NivelAcessoModel> NiveisAcesso { get; set; }
        //      RELACIONAMENTOS.     //
    }
}
