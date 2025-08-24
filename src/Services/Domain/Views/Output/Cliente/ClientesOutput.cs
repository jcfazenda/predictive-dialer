using System;
using System.Collections.Generic; 

namespace Services.Domain.Views.Output.Cliente
{
    public class ClientesOutput
    {

        public long idCliente { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public string ClienteCpf { get; set; } = string.Empty;
        public string ClienteEmail { get; set; } = string.Empty;
 

    }
}
