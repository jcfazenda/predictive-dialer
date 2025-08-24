using Services.Domain.Models.Operador;
using Services.Domain.Models.Empresa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Services.Domain.Mapping.Empresa
{
    public sealed class EmpresaOperadorMap : IEntityTypeConfiguration<EmpresaOperador>
    {
        public void Configure(EntityTypeBuilder<EmpresaOperador> constructor)
        {
            constructor.ToTable("OperadorEmpresa");

            constructor.Property(m => m.idOperador).HasColumnName("idOperador").IsRequired();
            constructor.HasKey(o => o.idOperador);

            constructor.Property(m => m.idEmpresa).HasColumnName("idEmpresa"); 
            
          
        }
    }
}
