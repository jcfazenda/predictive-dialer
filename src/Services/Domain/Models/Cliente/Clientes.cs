using System;
using System.Collections.Generic; 

namespace Services.Domain.Models.Cliente
{
    public class Clientes
    {
        public Clientes() { }

        public Clientes(long idCliente, string clienteNome, string clienteCpf, string clienteEmail)
        {
            this.idCliente = idCliente;
            this.ClienteNome = clienteNome;
            this.ClienteCpf = clienteCpf;
            this.ClienteEmail = clienteEmail;
        }

        public long idCliente { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public string ClienteCpf { get; set; } = string.Empty;
        public string ClienteEmail { get; set; } = string.Empty;
  
    }
}
