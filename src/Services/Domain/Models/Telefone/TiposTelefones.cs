using System;
using System.Collections.Generic;

namespace Services.Domain.Models.Telefone
{
    public class TiposTelefones
    {
        public TiposTelefones()
        {
        }

        public TiposTelefones(long idTipo,  string Nome )
        {
            this.idTipo = idTipo;
            this.Nome = Nome; 
        }

        public long idTipo { get; set; } 
        public string Nome { get; set; } = string.Empty; 
    }
}
