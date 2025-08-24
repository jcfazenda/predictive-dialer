namespace Services.Domain.Views.Output.Campanha
{
    public class RegrasDiscagemOutput
    {
        public long idRegra { get; set; }
        public long idStatus { get; set; }   // FK para StatusDiscagem
        public int QuantidadeTentativas { get; set; }
        public int IntervaloMinutos { get; set; }

    }
}
