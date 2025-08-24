namespace Services.Domain.Views.Input.Usuario
{
    public class UsuarioCargoAtividadeInput
    {
        public long idUsuarioCargoAtividade { get; set; }

        public string? UsuarioCargoAtividadeNome { get; set; }
        public string? UsuarioCargoAtividadeDescricao { get; set; }

        public bool? Ativo { get; set; }


        public long Id { get; set; }
        public string? Rota { get; set; }
    }
}
