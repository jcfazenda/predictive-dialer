using System;

namespace Services.Domain.Tenant
{
    public static class ConfigurationExtensions
    {
        public static string GetClientConnectionString(string clientName)
        {
            // Separar o nome do cliente para identificar o DB
            var item = clientName.Split('_');
            if (item.Length < 2)
                throw new ArgumentException("O nome do cliente deve estar no formato 'prefixo-nomeDB'.");

            var dbName = item[1];

            // Azure SQL padrão
            var server = "discador-replica.database.windows.net";
            var user = "discadoradmin";
            var password = "Apple@56"; // Coloque a senha real aqui

            // Montar connection string
            return $"Server=tcp:{server},1433;" +
                   $"Initial Catalog={dbName};" +
                   $"Persist Security Info=False;" +
                   $"User ID={user};" +
                   $"Password={password};" +
                   $"MultipleActiveResultSets=False;" +
                   $"Encrypt=True;" +
                   $"TrustServerCertificate=False;" +
                   $"Connection Timeout=30;";
        }
    }
}
