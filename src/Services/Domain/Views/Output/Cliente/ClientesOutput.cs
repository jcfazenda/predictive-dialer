using System;
using System.Collections.Generic;
using Services.Domain.Models.Cliente;  // Importa a classe Clientes
using Services.Domain.Models.Operador;  // Importa a classe Operador

namespace Services.Domain.Views.Output.Cliente
{
    public class ClientesOutput
    {

        public long idCampanha { get; set; }
        public long idEmpresa { get; set; }

        public string? CampanhaNome { get; set; }

        public DateTime DataSolicitacao { get; set; }
        public DateTime DataEntregaDiscador { get; set; }
        public string? Status { get; set; }
        public IEnumerable<Clientes>? Clientes { get; set; }

        public IEnumerable<Operadores>? Operadores { get; set; }

    }
}
