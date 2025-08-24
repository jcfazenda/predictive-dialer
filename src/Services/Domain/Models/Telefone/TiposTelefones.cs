using System;
using System.Collections.Generic;

namespace Services.Domain.Models.TiposTelefone
{
    public class TiposTelefone
    {
        public TiposTelefone()
        {
        }

        public TiposTelefone(long idTipo,  string Nome )
        {
            this.idTipo = idTipo;
            this.Nome = Nome; 
        }

        public long idTipo { get; set; } 
        public string Nome { get; set; } = string.Empty; 
    }
}
