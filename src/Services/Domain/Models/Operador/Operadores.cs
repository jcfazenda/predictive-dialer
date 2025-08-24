using System;
using System.Collections.Generic;

namespace Services.Domain.Models.Operador
{
    public class Operadores
    {
        public Operadores() { }

        public Operadores(long idOperador, string nome, string ramal, long idStatus)
        {
            this.idOperador = idOperador;
            this.Nome = nome;
            this.Ramal = ramal;
            this.idStatus = idStatus;
        }

        public long idOperador { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Ramal { get; set; } = string.Empty;
        public long idStatus { get; set; }

        // Navegação para EmpresaOperador
        public ICollection<Services.Domain.Models.Empresa.EmpresaOperador>? EmpresaOperadores { get; set; }
    }
}
