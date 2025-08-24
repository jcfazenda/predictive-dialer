using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Domain.Models.Cliente; 

namespace Services.Domain.Mapping.Cliente
{
    public sealed class ClientesMap : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> constructor)
        {
            constructor.ToTable("Clientes");

            constructor.Property(m => m.idCliente).HasColumnName("idCliente").IsRequired();
            constructor.HasKey(o => o.idCliente);

            constructor.Property(m => m.ClienteNome).HasColumnName("ClienteNome");
            constructor.Property(m => m.ClienteCpf).HasColumnName("ClienteCpf");
            constructor.Property(m => m.ClienteEmail).HasColumnName("ClienteEmail");
        }
    }
}
