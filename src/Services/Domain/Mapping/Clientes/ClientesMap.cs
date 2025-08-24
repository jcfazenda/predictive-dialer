using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelsClientes = Services.Domain.Models.Cliente; // alias para o namespace

namespace Services.Domain.Mapping.Clientes
{
    public sealed class ClientesMap : IEntityTypeConfiguration<ModelsClientes.Clientes>
    {
        public void Configure(EntityTypeBuilder<ModelsClientes.Clientes> constructor)
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
