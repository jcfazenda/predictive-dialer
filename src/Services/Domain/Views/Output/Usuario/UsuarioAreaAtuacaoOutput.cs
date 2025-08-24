namespace Services.Domain.Views.Output.Usuario
{
    public class UsuarioAreaAtuacaoOutput
    {
        public long idUsuarioAreaAtuacao { get; set; }

        public string? UsuarioAreaAtuacaoNome { get; set; }
        public string? UsuarioAreaAtuacaoDescricao { get; set; }

        public bool? Ativo { get; set; }
    }
}
