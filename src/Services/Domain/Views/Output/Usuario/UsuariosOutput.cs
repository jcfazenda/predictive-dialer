using Services.Domain.Models.Usuario;

namespace Services.Domain.Views.Output.Usuario
{
    public class UsuariosOutput
    {
        public ulong idUsuario { get; set; }
        public ulong idCliente { get; set; }

        public string? UsuarioNome { get; set; }
        public string? UsuarioSobrenome { get; set; }
        public string? UsuarioEmail { get; set; }
       public string? UsuarioSenha { get; set; }
        public string? UsuarioAvatar { get; set; }


        public byte? Ativo { get; set; }

    }
}
