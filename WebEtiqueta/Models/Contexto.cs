
using Microsoft.EntityFrameworkCore;

namespace WebEtiqueta.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<EtiquetaModel> Etiqueta { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<MatrizModel> Matriz { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>()
                .HasOne(u => u.Matriz)              // Define o relacionamento 1 para 1 ou N para 1 entre Usuario e Matriz
                .WithMany(m => m.Usuarios)          // Define que a Matriz pode ter muitos Usuários
                .HasForeignKey(u => u.MatrizId);    // Define a chave estrangeira em Usuario

            //      TABELA ETIQUETA.     //
            modelBuilder.Entity<EtiquetaModel>()
                .HasOne(e => e.Matriz)
                .WithMany(m => m.Etiquetas)
                .HasForeignKey(e => e.MatrizId);

            //     /TABELA ETIQUETA.     //

        }
    }
}
