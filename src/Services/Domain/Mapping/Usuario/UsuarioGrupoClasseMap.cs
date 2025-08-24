
using Services.Domain.Models.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Services.Domain.Mapping.Usuario
{
    public sealed class UsuarioGrupoClasseMap : IEntityTypeConfiguration<UsuarioGrupoClasse>
    {

        public void Configure(EntityTypeBuilder<UsuarioGrupoClasse> constuctor)
        {

            constuctor.ToTable("usuariogrupoclasse");

            constuctor.Property(m => m.idUsuarioGrupoClasse).HasColumnName("idUsuarioGrupoClasse").IsRequired();
            constuctor.HasKey(o => o.idUsuarioGrupoClasse);

            constuctor.Property(m => m.UsuarioGrupoClasseNome).HasColumnName("UsuarioGrupoClasseNome");
            constuctor.Property(m => m.UsuarioGrupoClasseDescricao).HasColumnName("UsuarioGrupoClasseDescricao");
            constuctor.Property(m => m.Ativo).HasColumnName("Ativo");

        }
    }
}
