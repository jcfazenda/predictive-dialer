using Services.Domain.Models.Campanha;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Services.Domain.Mapping.Campanha
{
    public sealed class RegrasDiscagemMap : IEntityTypeConfiguration<RegrasDiscagem>
    {
        public void Configure(EntityTypeBuilder<RegrasDiscagem> constructor)
        {
            constructor.ToTable("RegrasDiscagem");

            constructor.Property(m => m.idRegra).HasColumnName("idRegra").IsRequired();
            constructor.HasKey(o => o.idRegra);

            constructor.Property(m => m.idStatus).HasColumnName("idStatus");
            constructor.Property(m => m.QuantidadeTentativas).HasColumnName("QuantidadeTentativas");
            constructor.Property(m => m.IntervaloMinutos).HasColumnName("IntervaloMinutos"); 
                     
        }
    }
}
