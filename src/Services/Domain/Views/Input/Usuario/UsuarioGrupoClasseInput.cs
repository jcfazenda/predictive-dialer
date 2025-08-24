namespace Services.Domain.Views.Input.Usuario
{
    public class UsuarioGrupoClasseInput
    {
        public long idUsuarioGrupoClasse { get; set; }

        public string? UsuarioGrupoClasseNome { get; set; }
        public string? UsuarioGrupoClasseDescricao { get; set; }

        public bool? Ativo { get; set; }

        public long Id { get; set; }
        public string? Rota { get; set; }
    }


}
