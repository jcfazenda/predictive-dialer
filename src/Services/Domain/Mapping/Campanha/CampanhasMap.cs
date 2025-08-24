using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Domain.Models.Campanha;
using Services.Domain.Models.Empresa;  

namespace Services.Domain.Mapping.Campanha
{
    public sealed class CampanhasMap : IEntityTypeConfiguration<Campanhas>
    {
        public void Configure(EntityTypeBuilder<Campanhas> constructor)
        {
            constructor.ToTable("Campanhas");

            constructor.Property(m => m.idCampanha).HasColumnName("idCampanha").IsRequired();
            constructor.HasKey(o => o.idCampanha);

            constructor.Property(m => m.idEmpresa).HasColumnName("idEmpresa");
            constructor.Property(m => m.CampanhaNome).HasColumnName("CampanhaNome"); 

            constructor.HasOne(m => m.Empresas)            // Uma Campanha tem 1 Empresa
                    .WithMany(e => e.Campanhas)           // Uma Empresa tem várias Campanhas
                    .HasForeignKey(c => c.idEmpresa)      // FK em Campanhas
                    .HasPrincipalKey(e => e.idEmpresa);   // PK em Empresas

        }
    }
}
