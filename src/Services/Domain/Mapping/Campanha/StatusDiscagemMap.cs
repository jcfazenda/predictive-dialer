using Services.Domain.Models.Campanha;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Services.Domain.Mapping.Campanhas
{
    public sealed class StatusDiscagemMap : IEntityTypeConfiguration<StatusDiscagem>
    {

        public void Configure(EntityTypeBuilder<StatusDiscagem> constuctor)
        { 
            constuctor.ToTable("StatusDiscagem"); 

            constuctor.Property(m => m.idStatus).HasColumnName("idStatus").IsRequired();
            constuctor.HasKey(o => o.idStatus);
              
            constuctor.Property(m => m.NomeStatus).HasColumnName("NomeStatus"); 
        }
    }
}
