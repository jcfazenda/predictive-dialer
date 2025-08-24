using System;
using System.Collections.Generic;
using Services.Domain.Models.Cliente;  
using Services.Domain.Models.Operador;  

namespace Services.Domain.Views.Input.Campanha
{
    public class CampanhasInput
    {
        public long idCampanha { get; set; } 
        public long idEmpresa { get; set; }

        public string? CampanhaNome { get; set; } 
  
    }
}
