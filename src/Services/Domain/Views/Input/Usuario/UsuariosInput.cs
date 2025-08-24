namespace Services.Domain.Views.Input.Usuario
{
    public class UsuariosInput
    {
        public long idUsuario { get; set; }

        public string? UsuarioNome { get; set; }
        public string? UsuarioSobrenome { get; set; }
        public string? UsuarioEmail { get; set; }
        public string? UsuarioSenha { get; set; }
        public string? UsuarioAvatar { get; set; }

        public byte? Ativo { get; set; }
        public long idCliente { get; set; }
        public string? Rota { get; set; }

    }
}
