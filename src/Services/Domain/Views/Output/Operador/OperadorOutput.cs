namespace Services.Domain.Views.Output.Operador
{
    public class OperadorOutput
    {
        public long idOperador { get; set; }
        public long idStatus { get; set; }  // Status atual do operador (ex: livre, ocupado)
        public string OperadorNome { get; set; } = string.Empty;
        public string Ramal { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } 
    }
}
