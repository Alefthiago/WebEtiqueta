using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
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
        [Column("USUARIO_MATRIZ_ID")]
        public int MatrizId { get; set; }

        [Required]
        [Column("USUARIO_TIPO")]
        public int TipoId { get; set; }
        //     /CAMPOS.     //

        //      RELACIONAMENTOS.     //
        public MatrizModel Matriz { get; set; }
        public TipoUsuarioModel Tipo { get; set; }
        public List<UsuarioFilialModel> UsuarioFilials { get; set; }
        //      RELACIONAMENTOS.     //


        public UsuarioModel(String login, String senha)
        {
            this.Login = login;
            this.Senha = senha;
        }

        public bool VerificarSenhaLogin(string senha)
        {
            var hasher = new PasswordHasher<string>();

            var senhaValida = hasher.VerifyHashedPassword(this.Login, this.Senha, senha);

            if (senhaValida == PasswordVerificationResult.Success)
            {
                return true;
            }

            return false;
        }

    }
}
