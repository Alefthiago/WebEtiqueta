using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
    public class UsuarioModel
    {
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
        [ForeignKey("MatrizId")]
        public int MatrizId { get; set; }

        // Construtor para Login
        public UsuarioModel(String login, String senha)
        {
            this.Login = login;
            this.Senha = senha;
        }
    }
}
