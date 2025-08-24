
using Services.Domain.Mapping.Usuario;
using Services.Domain.Mapping.Campanha;
using Services.Domain.Mapping.Empresa;

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
            modelBuilder.ApplyConfiguration(new UsuariosMap());
            modelBuilder.ApplyConfiguration(new CampanhasMap());
            modelBuilder.ApplyConfiguration(new EmpresasMap());

            base.OnModelCreating(modelBuilder);
        }
         
    }
}
