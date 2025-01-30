
using Microsoft.EntityFrameworkCore;

namespace WebEtiqueta.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Etiqueta> Etiqueta { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
