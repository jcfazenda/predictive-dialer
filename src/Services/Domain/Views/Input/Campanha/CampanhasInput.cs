using System;
using System.Collections.Generic;
using Services.Domain.Models.Cliente;   // Importa a classe Clientes
using Services.Domain.Models.Operador;   // Importa a classe Operador

namespace Services.Domain.Views.Input.Campanhas
{
    public class CampanhasInput
    {
        public long idCampanha { get; set; } 
        public long idEmpresa { get; set; }

        public string? CampanhaNome { get; set; }

        public DateTime DataSolicitacao { get; set; }
        public DateTime DataEntregaDiscador { get; set; } 
        public string? Status { get; set; }  
  
    }
}
