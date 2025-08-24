using System;
using System.Collections.Generic;
using Services.Domain.Models.Cliente;   
using Services.Domain.Models.Operador;   

namespace Services.Domain.Models.Campanha
{
    public class Campanhas
    {
        public Campanhas() { }

        public Campanhas(long idCampanha, long idEmpresa, string campanhaNome, DateTime dataSolicitacao, DateTime dataEntregaDiscador)
        {
            this.idCampanha = idCampanha;
            this.idEmpresa = idEmpresa;
            this.CampanhaNome = campanhaNome;
            this.DataSolicitacao = dataSolicitacao;
            this.DataEntregaDiscador = dataEntregaDiscador;
        }

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
