 
using Services.Domain.Models.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Servives.Domain.Mapping.Usuario
{
    public sealed class UsuarioCargoAtividadeMap : IEntityTypeConfiguration<UsuarioCargoAtividade>
    {

        public void Configure(EntityTypeBuilder<UsuarioCargoAtividade> constuctor)
        {

            constuctor.ToTable("usuariocargoatividade");

            constuctor.Property(m => m.idUsuarioCargoAtividade).HasColumnName("idUsuarioCargoAtividade").IsRequired();
            constuctor.HasKey(o => o.idUsuarioCargoAtividade);

            constuctor.Property(m => m.UsuarioCargoAtividadeNome).HasColumnName("UsuarioCargoAtividadeNome");
            constuctor.Property(m => m.UsuarioCargoAtividadeDescricao).HasColumnName("UsuarioCargoAtividadeDescricao"); 
            constuctor.Property(m => m.Ativo).HasColumnName("Ativo");

        }
    }
}
