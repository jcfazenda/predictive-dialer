using System.Collections.Generic;

namespace Services.Domain.Models.Usuario
{
    public class UsuarioAreaAtuacao
    {
        public UsuarioAreaAtuacao()
        {
        }

public UsuarioAreaAtuacao(long idUsuarioAreaAtuacao, string UsuarioAreaAtuacaoNome, string UsuarioAreaAtuacaoDescricao, bool? Ativo)
{
    this.idUsuarioAreaAtuacao = idUsuarioAreaAtuacao;
    this.UsuarioAreaAtuacaoNome = UsuarioAreaAtuacaoNome;
    this.UsuarioAreaAtuacaoDescricao = UsuarioAreaAtuacaoDescricao;
    this.Ativo = Ativo;
}


        public long idUsuarioAreaAtuacao { get; set; }

        public string? UsuarioAreaAtuacaoNome { get; set; }
        public string? UsuarioAreaAtuacaoDescricao { get; set; }

        public bool? Ativo { get; set; }
        public IEnumerable<Usuarios>? Usuarios { get; set; }
    }
}
