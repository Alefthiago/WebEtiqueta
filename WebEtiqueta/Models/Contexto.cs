using Microsoft.EntityFrameworkCore;

namespace WebEtiqueta.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<EmpresaModel> Empresa { get; set; }
        public DbSet<EtiquetaModel> Etiqueta { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<NivelAcessoModel> NivelAcesso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //      TABELA ETIQUETA.     //
            modelBuilder.Entity<EtiquetaModel>() // Relacionamento com a tabela Usuario.
                .HasOne(e => e.Eliminador)
                .WithMany(u => u.EtiquetasEliminadas)
                .HasForeignKey(e => e.EliminadoPor);
            modelBuilder.Entity<EtiquetaModel>() // Relacionamento com a tabela Empresa.
                .HasOne(e => e.Empresa)
                .WithMany(m => m.Etiquetas)
                .HasForeignKey(e => e.EmpresaId);
            //     /TABELA ETIQUETA.     //

            //      TABELA USUARIO.     //
            modelBuilder.Entity<UsuarioModel>() // Relacionamento com a tabela Empresa.
                .HasOne(u => u.Empresa)
                .WithMany(m => m.Usuarios)
                .HasForeignKey(u => u.EmpresaId);
            modelBuilder.Entity<UsuarioModel>() // Relacionamento com a tabela NivelAcesso.
                .HasOne(u => u.NivelAcesso)
                .WithMany(n => n.Usuarios)
                .HasForeignKey(u => u.NivelAcessoId);
            modelBuilder.Entity<UsuarioModel>() // Relacionamento com a tabela Usuario.
                .HasOne(u => u.Eliminador)
                .WithMany(u => u.UsuariosEliminados)
                .HasForeignKey(u => u.EliminadoPor);
            //     /TABELA USUARIO.     //

            //      TABELA NIVEL_ACESSO.     //
            modelBuilder.Entity<NivelAcessoModel>() // Relacionamento com a tabela Empresa.
                .HasOne(n => n.Empresa)
                .WithMany(m => m.NiveisAcesso)
                .HasForeignKey(n => n.EmpresaId);
            modelBuilder.Entity<NivelAcessoModel>() // Relacionamento com a tabela Usuario.
                .HasOne(n => n.Eliminador)
                .WithMany(u => u.NiveisAcessoEliminados)
                .HasForeignKey(n => n.EliminadoPor);
            //     /TABELA NIVEL_ACESSO.     //

            modelBuilder.Entity<EmpresaModel>()
                .HasData(
                    new EmpresaModel { 
                        Id      = 1,
                        Nome    = "suporte",
                        CnpjCpf = "00000000000000"
                    },
                    new EmpresaModel
                    {
                        Id = 2,
                        Nome = "empresa 2",
                        CnpjCpf = "00748572000153"
                    }
                );
            modelBuilder.Entity<NivelAcessoModel>()
                .HasData(
                    new NivelAcessoModel
                    {
                        Id                  = 1,
                        Nome                = "suporte",
                        Log                 = true,
                        AdicionarUsuario    = true,
                        EditarUsuario       = true,
                        ExcluirUsuario      = true,
                        AdicionarEtiqueta   = true,
                        EditarEtiqueta      = true,
                        ExcluirEtiqueta     = true,
                        Eliminado           = false,
                        EmpresaId           = 1
                    }
                );
            modelBuilder.Entity<EtiquetaModel>()
             .HasData(
                 Enumerable.Range(1, 50).Select(i => new EtiquetaModel
                 {
                     Id         = i,
                     Nome       = $"etiqueta {i}",
                     Colunas    = 2,
                     Linhas     = 2,
                     Modelo     = "modelo",
                     Largura    = 100,
                     Altura     = 100,
                     EspacoX    = 10,
                     EspacoY    = 10,
                     Tipo       = "tipo",
                     Eliminado  = false,
                     EmpresaId  = 2
                 }).ToArray()
             );
            modelBuilder.Entity<UsuarioModel>()
                .HasData(
                    new UsuarioModel { 
                        Id              = 1,
                        Nome            = "suporte",
                        Login           = "suporte",
                        Senha           = "AQAAAAIAAYagAAAAEAH7K+qacDcQl3Iw8EB617kxQ39wbjr5PfBAJtfxHNS79SSubo1NIBwgOx2KqJh+eA==",
                        EmpresaId       = 1,
                        NivelAcessoId   = 1,
                        Eliminado       = false
                    }
                );
        }
    }
}