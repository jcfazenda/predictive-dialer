namespace Services.Domain.Views.Output.Campanha
{
    public class CampanhasOutput
    {
        public long idCampanha { get; set; }
        public long idEmpresa { get; set; }

        public string? CampanhaNome { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataEntregaDiscador { get; set; }
        public string? Status { get; set; }
 

    }
}
