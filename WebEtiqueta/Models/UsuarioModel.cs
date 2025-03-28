using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
    [Table("USUARIO")]
    public class UsuarioModel
    {
        //      CAMPOS.     //
        [Key]
        [Column("USUARIO_ID")]
        public int Id { get; set; }

        [Required]
        [Column("USUARIO_NOME")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column("USUARIO_LOGIN")]
        [StringLength(100)]
        public string Login { get; set; }

        [Required]
        [Column("USUARIO_SENHA")]
        [StringLength(250)]
        public string Senha { get; set; }

        [Required]
        [Column("USUARIO_ELIMINADO")]
        public bool Eliminado { get; set; }
        //     /CAMPOS.     //

        //      RELACIONAMENTOS.     //
        [Required]
        [Column("USUARIO_EMPRESA_ID")]
        public int EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }

        [Required]
        [Column("USUARIO_NIVEL_ACESSO_ID")]
        public int NivelAcessoId { get; set; }
        public NivelAcessoModel NivelAcesso { get; set; }

        [Column("USUARIO_ELIMINADO_DATA")]
        public DateTime? EliminadoData { get; set; }

        [Column("USUARIO_ELIMINADO_POR")]
        public int? EliminadoPor { get; set; }
        public UsuarioModel? Eliminador { get; set; }

        public ICollection<EtiquetaModel> EtiquetasEliminadas { get; set; }
        public ICollection<UsuarioModel> UsuariosEliminados { get; set; }
        public ICollection<NivelAcessoModel> NiveisAcessoEliminados { get; set; }
        //      RELACIONAMENTOS.     //

        public UsuarioModel()
        {
        }
        public UsuarioModel(String login, String senha)
        {
            this.Login = login;
            this.Senha = senha;
        }
    }
}
