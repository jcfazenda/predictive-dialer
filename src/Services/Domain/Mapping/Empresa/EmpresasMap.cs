using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Domain.Models.Empresa; // alias para o namespace

namespace Services.Domain.Mapping.Empresa
{
    public sealed class EmpresasMap : IEntityTypeConfiguration<Empresas>
    {
        public void Configure(EntityTypeBuilder<Empresas> constructor)
        { 
            constructor.ToTable("Empresas"); 

            constructor.Property(m => m.idEmpresa).HasColumnName("idEmpresa").IsRequired();
            constructor.HasKey(o => o.idEmpresa);
              
            constructor.Property(m => m.EmpresaNome).HasColumnName("EmpresaNome"); 
        }
    }
}
