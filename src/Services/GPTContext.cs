
using Services.Domain.Mapping.Usuario;
 
using Microsoft.EntityFrameworkCore;
 

namespace Services
{
    public class GRCContext : DbContext
    {
        public GRCContext()
        {

        }

        public GRCContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* usuarios */
            modelBuilder.ApplyConfiguration(new UsuariosMap());

            base.OnModelCreating(modelBuilder);
        }
         
    }
}
