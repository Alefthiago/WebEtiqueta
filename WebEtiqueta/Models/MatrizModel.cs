using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
    [Table("MATRIZ")]
    public class MatrizModel
    {
        //      CAMPOS.     //
        [Key]
        [Column("MATRIZ_ID")]
        public int Id { get; set; }

        [Required]
        [Column("MATRIZ_NOME")]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required]
        [Column("MATRIZ_CNPJ_CPF")]
        [StringLength(14)]
        public string CnpjCpf { get; set; }
        //     /CAMPOS.     //

        //      RELACIONAMENTOS.     //
        public ICollection<UsuarioModel> Usuarios { get; set; }
        public ICollection<EtiquetaModel> Etiquetas { get; set; }
        public ICollection<FilialModel> Filiais { get; set; }
        //      RELACIONAMENTOS.     //
    }
}
