using System.Collections.Generic;

namespace Services.Domain.Models.Usuario
{
    public class UsuarioCargoAtividade
    {
        public UsuarioCargoAtividade()
        {
        }

public UsuarioCargoAtividade(long idUsuarioCargoAtividade, string UsuarioCargoAtividadeNome, string UsuarioCargoAtividadeDescricao, bool? Ativo)
{
    this.idUsuarioCargoAtividade = idUsuarioCargoAtividade;
    this.UsuarioCargoAtividadeNome = UsuarioCargoAtividadeNome;
    this.UsuarioCargoAtividadeDescricao = UsuarioCargoAtividadeDescricao;
    this.Ativo = Ativo;
}


        public long idUsuarioCargoAtividade { get; set; } 

        public string? UsuarioCargoAtividadeNome { get; set; }
        public string? UsuarioCargoAtividadeDescricao { get; set; } 

        public bool? Ativo { get; set; }
        public IEnumerable<Usuarios>? Usuarios { get; set; }
    }
}
