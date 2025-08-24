using System;
using System.Collections.Generic;

namespace Services.Domain.Models.Operador
{
    public class Operadores
    {
        public Operadores() { }

        public Operadores(long idOperador, string OperadorNome, string ramal, long idStatus)
        {
            this.idOperador = idOperador;
            this.OperadorNome = OperadorNome;
            this.Ramal = ramal;
            this.idStatus = idStatus;
        }

        public long idOperador { get; set; }
        public string OperadorNome { get; set; } = string.Empty;
        public string Ramal { get; set; } = string.Empty;
        public long idStatus { get; set; }
 
    }
}
