using System;
using System.Collections.Generic;
using Services.Domain.Models.Cliente;   
using Services.Domain.Models.Operador;
using Services.Domain.Models.Empresa;

namespace Services.Domain.Models.Campanha
{
    public class Campanhas
    {
        public Campanhas() { }

        public Campanhas(long idCampanha, long idEmpresa, string campanhaNome)
        {
            this.idCampanha = idCampanha;
            this.idEmpresa = idEmpresa;
            this.CampanhaNome = campanhaNome; 
        }

        public long idCampanha { get; set; }
        public long idEmpresa { get; set; }

        public string? CampanhaNome { get; set; } 

        public Empresas? Empresas { get; set; } // 🔹 Navegação para Empresa (JOIN)
    }
}
