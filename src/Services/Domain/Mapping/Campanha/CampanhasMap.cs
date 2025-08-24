using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelsCampanhas = Services.Domain.Models.Campanha; // alias para o namespace

namespace Services.Domain.Mapping.Campanha
{
    public sealed class CampanhasMap : IEntityTypeConfiguration<ModelsCampanhas.Campanhas>
    {
        public void Configure(EntityTypeBuilder<ModelsCampanhas.Campanhas> constructor)
        {
            constructor.ToTable("Campanhas");

            constructor.Property(m => m.idCampanha).HasColumnName("idCampanha").IsRequired();
            constructor.HasKey(o => o.idCampanha);

            constructor.Property(m => m.idEmpresa).HasColumnName("idEmpresa");
            constructor.Property(m => m.CampanhaNome).HasColumnName("CampanhaNome");
            constructor.Property(m => m.DataSolicitacao).HasColumnName("DataSolicitacao");
            constructor.Property(m => m.DataEntregaDiscador).HasColumnName("DataEntregaDiscador");

            constructor.HasOne(m => m.Empresa)               // Navegação para Empresa
                       .WithMany(e => e.Campanhas)          // Uma empresa tem várias campanhas
                       .HasForeignKey(c => c.idEmpresa)     // FK em Campanhas
                       .HasPrincipalKey(e => e.idEmpresa); // PK na tabela Empresa
        }
    }
}
