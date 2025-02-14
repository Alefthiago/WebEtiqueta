
using Microsoft.EntityFrameworkCore;

namespace WebEtiqueta.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<MatrizModel> Matriz { get; set; }
        public DbSet<EtiquetaModel> Etiqueta { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<UsuarioFilialModel> UsuarioFilial { get; set; }
        public DbSet<FilialModel> Filial { get; set; }
        public DbSet<FilialEtiquetaModel> FilialEtiqueta { get; set; }
        public DbSet<NivelAcessoModel> NivelAcesso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //      TABELA ETIQUETA.     //
            modelBuilder.Entity<EtiquetaModel>() // Relacionamento com a tabela Usuario.
                .HasOne(e => e.Eliminador)
                .WithMany(u => u.EtiquetasEliminadas)
                .HasForeignKey(e => e.EliminadoPor);
            modelBuilder.Entity<EtiquetaModel>() // Relacionamento com a tabela Matriz.
                .HasOne(e => e.Matriz)
                .WithMany(m => m.Etiquetas)
                .HasForeignKey(e => e.MatrizId);
            //     /TABELA ETIQUETA.     //

            //      TABELA USUARIO.     //
            modelBuilder.Entity<UsuarioModel>() // Relacionamento com a tabela Matriz.
                .HasOne(u => u.Matriz)
                .WithMany(m => m.Usuarios)
                .HasForeignKey(u => u.MatrizId);
            modelBuilder.Entity<UsuarioModel>() // Relacionamento com a tabela NivelAcesso.
                .HasOne(u => u.NivelAcesso)
                .WithMany(n => n.Usuarios)
                .HasForeignKey(u => u.NivelAcessoId);
            modelBuilder.Entity<UsuarioModel>() // Relacionamento com a tabela Usuario.
                .HasOne(u => u.Eliminador)
                .WithMany(u => u.UsuariosEliminados)
                .HasForeignKey(u => u.EliminadoPor);
            //     /TABELA USUARIO.     //

            //      TABELA FILIAL.     //
            modelBuilder.Entity<FilialModel>() // Relacionamento com a tabela Matriz.
                .HasOne(f => f.Matriz)
                .WithMany(m => m.Filiais)
                .HasForeignKey(f => f.MatrizId);
            modelBuilder.Entity<FilialModel>() // Relacionamento com a tabela Usuario.
                .HasOne(f => f.Eliminador)
                .WithMany(u => u.FiliaisEliminadas)
                .HasForeignKey(f => f.EliminadoPor);
            //     /TABELA FILIAL.     //

            //      TABELA USUARIO_FILIAL.     //
            modelBuilder.Entity<UsuarioFilialModel>()
                .HasKey(sc => new { sc.UsuarioId, sc.FilialId });
            modelBuilder.Entity<UsuarioFilialModel>()
                .HasOne(uf => uf.Usuario)
                .WithMany(u => u.Filiais)
                .HasForeignKey(uf => uf.UsuarioId);
            modelBuilder.Entity<UsuarioFilialModel>()
                .HasOne(uf => uf.Filial)
                .WithMany(f => f.Usuarios)
                .HasForeignKey(uf => uf.FilialId);
            //     /TABELA USUARIO_FILIAL.     //

            //      TABELA FILIAL_ETIQUETA.     //
            modelBuilder.Entity<FilialEtiquetaModel>()
                .HasKey(sc => new { sc.FilialId, sc.EtiquetaId });
            modelBuilder.Entity<FilialEtiquetaModel>()
                .HasOne(fe => fe.Filial)
                .WithMany(f => f.Etiquetas)
                .HasForeignKey(fe => fe.FilialId);
            modelBuilder.Entity<FilialEtiquetaModel>()
                .HasOne(fe => fe.Etiqueta)
                .WithMany(e => e.Filiais)
                .HasForeignKey(fe => fe.EtiquetaId);
            //     /TABELA FILIAL_ETIQUETA.     //

            //      TABELA NIVEL_ACESSO.     //
            modelBuilder.Entity<NivelAcessoModel>() // Relacionamento com a tabela Matriz.
                .HasOne(n => n.Matriz)
                .WithMany(m => m.NiveisAcesso)
                .HasForeignKey(n => n.MatrizId);
            modelBuilder.Entity<NivelAcessoModel>() // Relacionamento com a tabela Usuario.
                .HasOne(n => n.Eliminador)
                .WithMany(u => u.NiveisAcessoEliminados)
                .HasForeignKey(n => n.EliminadoPor);
            //     /TABELA NIVEL_ACESSO.     //

            modelBuilder.Entity<MatrizModel>()
                .HasData(
                    new MatrizModel { 
                        Id      = 1,
                        Nome    = "Matriz",
                        CnpjCpf = "00000000000000"
                    }
                );
            modelBuilder.Entity<NivelAcessoModel>()
                .HasData(
                    new NivelAcessoModel
                    {
                        Id                  = 1,
                        Nome                = "Administrador",
                        AdicionarUsuario    = true,
                        EditarUsuario       = true,
                        ExcluirUsuario      = true,
                        AdicionarEtiqueta   = true,
                        EditarEtiqueta      = true,
                        ExcluirEtiqueta     = true,
                        AdicionarFilial     = true,
                        EditarFilial        = true,
                        ExcluirFilial       = true,
                        Eliminado           = false,
                        MatrizId            = 1
                    }
                );
            modelBuilder.Entity<UsuarioModel>()
                .HasData(
                    new UsuarioModel { 
                        Id              = 1,
                        Nome            = "suporte",
                        Login           = "suporte",
                        Senha           = "AQAAAAIAAYagAAAAEAH7K+qacDcQl3Iw8EB617kxQ39wbjr5PfBAJtfxHNS79SSubo1NIBwgOx2KqJh+eA==",
                        MatrizId        = 1,
                        NivelAcessoId   = 1,
                        Eliminado       = false
                    }
                );
        }
    }
}