using Services.Domain.Models.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Services.Domain.Mapping.Usuario
{
    public sealed class UsuariosMap : IEntityTypeConfiguration<Usuarios>
    {

        public void Configure(EntityTypeBuilder<Usuarios> constuctor)
        {

            constuctor.ToTable("Usuarios");


            constuctor.Property(m => m.idUsuario).HasColumnName("idUsuario").IsRequired();
            constuctor.HasKey(o => o.idUsuario);
              
            constuctor.Property(m => m.UsuarioNome).HasColumnName("UsuarioNome");
            constuctor.Property(m => m.UsuarioSobrenome).HasColumnName("UsuarioSobrenome");
            constuctor.Property(m => m.UsuarioEmail).HasColumnName("UsuarioEmail");
            constuctor.Property(m => m.UsuarioSenha).HasColumnName("UsuarioSenha");
            constuctor.Property(m => m.UsuarioAvatar).HasColumnName("UsuarioAvatar"); 
            constuctor.Property(m => m.Ativo).HasColumnName("Ativo");


        }
    }
}
