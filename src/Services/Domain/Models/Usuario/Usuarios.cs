 
using System.Collections.Generic;

namespace Services.Domain.Models.Usuario
{
    public class Usuarios  
    {
        public Usuarios()
        {
        }

        public Usuarios(long idUsuario, long idCliente, string UsuarioNome, string UsuarioSobrenome, string UsuarioEmail, string UsuarioSenha, string UsuarioAvatar, byte? Ativo)
        {
            this.idUsuario = idUsuario; 
            this.idCliente = idCliente;
            this.UsuarioNome = UsuarioNome;
            this.UsuarioSobrenome = UsuarioSobrenome;
            this.UsuarioEmail = UsuarioEmail;
            this.UsuarioSenha = UsuarioSenha;
            this.UsuarioAvatar = UsuarioAvatar;
            this.Ativo = Ativo;
        }


        public long idUsuario { get; set; } 
        public long idCliente { get; set; }

        public string? UsuarioNome { get; set; }
        public string? UsuarioSobrenome { get; set; }
        public string? UsuarioEmail { get; set; }
        public string? UsuarioSenha { get; set; }
        public string? UsuarioAvatar { get; set; } 

        public byte? Ativo { get; set; }

    }
}
