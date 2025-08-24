using System;
using System.Collections.Generic;
using Services.Domain.Models.Campanha;  

namespace Services.Domain.Models.Empresa
{
    public class Empresas
    {
        public Empresas() { }

        public Empresas(long idEmpresa, string empresaNome)
        {
            this.idEmpresa = idEmpresa;
            this.EmpresaNome = empresaNome;
        }

        public long idEmpresa { get; set; }
        public string EmpresaNome { get; set; } = string.Empty;

        public ICollection<Campanhas>? Campanhas { get; set; }
 
    }
}
