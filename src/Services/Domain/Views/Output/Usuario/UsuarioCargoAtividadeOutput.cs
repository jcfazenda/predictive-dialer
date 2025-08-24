namespace Services.Domain.Views.Output.Usuario
{
    public class UsuarioCargoAtividadeOutput
    {
        public long idUsuarioCargoAtividade { get; set; }

        public string? UsuarioCargoAtividadeNome { get; set; }
        public string? UsuarioCargoAtividadeDescricao { get; set; }

        public bool? Ativo { get; set; }
    }
}
