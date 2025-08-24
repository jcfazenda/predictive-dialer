namespace Services.Domain.Views.Input.Usuario
{
    public class UsuarioAreaAtuacaoInput
    {
         
        public long idUsuarioAreaAtuacao { get; set; }

        public string? UsuarioAreaAtuacaoNome { get; set; }
        public string? UsuarioAreaAtuacaoDescricao { get; set; }

        public bool? Ativo { get; set; }

        public long Id { get; set; }
        public string? Rota { get; set; }
    }
}
