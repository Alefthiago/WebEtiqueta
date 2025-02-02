﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEtiqueta.Models
{
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

        [Required]
        [Column("NIVEL_ACESSO_ADICIONAR_FILIAR")]
        public bool AdicionarFilial { get; set; }

        [Required]
        [Column("NIVEL_ACESSO_EDITAR_FILIAR")]
        public bool EditarFilial { get; set; }

        [Required]
        [Column("NIVEL_ACESSO_EXCLUIR_FILIAR")]
        public bool ExcluirFilial { get; set; }
        //      CAMPOS.     //

        //      RELACIONAMENTOS.     //
        public List<TipoUsuarioModel> TipoUsuarios { get; set; }
        //     /RELACIONAMENTOS.     //

    }
}
