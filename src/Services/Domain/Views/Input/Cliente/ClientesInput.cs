namespace Services.Domain.Views.Input.Clientes
{
    public class ClientesInput
    {
        public long idCliente { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public string ClienteCpf { get; set; } = string.Empty;
        public string ClienteEmail { get; set; } = string.Empty; 

    }
}
