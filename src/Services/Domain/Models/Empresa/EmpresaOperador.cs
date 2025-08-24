using System;
using System.Collections.Generic;

namespace Services.Domain.Models.Empresa
{
    public class EmpresaOperador
    {
        public EmpresaOperador() { }

        public EmpresaOperador(long idOperador, long idEmpresa)
        {
            this.idOperador = idOperador;
            this.idEmpresa = idEmpresa;
        }

        public long idOperador { get; set; }
        public long idEmpresa { get; set; }
 
    }
}
