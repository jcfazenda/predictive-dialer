using System.Collections.Generic;

namespace Services.Domain.Models.Usuario
{
    public class UsuarioGrupoClasse
    {
        public UsuarioGrupoClasse()
        {
        }

public UsuarioGrupoClasse(long idUsuarioGrupoClasse, string UsuarioGrupoClasseNome, string UsuarioGrupoClasseDescricao, bool? Ativo)
{
    this.idUsuarioGrupoClasse = idUsuarioGrupoClasse;
    this.UsuarioGrupoClasseNome = UsuarioGrupoClasseNome;
    this.UsuarioGrupoClasseDescricao = UsuarioGrupoClasseDescricao;
    this.Ativo = Ativo;
}


        public long idUsuarioGrupoClasse { get; set; }

        public string? UsuarioGrupoClasseNome { get; set; }
        public string? UsuarioGrupoClasseDescricao { get; set; }

        public bool? Ativo { get; set; }

        public IEnumerable<Usuarios>? Usuarios { get;  set; }
    }
}
