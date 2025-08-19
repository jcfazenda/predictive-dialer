using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Domain.Tenant
{
    public static class CustomerDataContextExtensions
    {
        public static void AddCustomerDbContext(this IServiceCollection services)
        {
            services.AddScoped(provider =>
            {
                var httpContextAccessor = provider.GetService<IHttpContextAccessor>();

                // Checa se o HttpContextAccessor ou HttpContext é null
                var path = httpContextAccessor?.HttpContext?.Request?.Path.Value;
                if (string.IsNullOrEmpty(path))
                    throw new InvalidOperationException("HttpContext ou Path não disponível.");

                // Recupera o primeiro segmento da URL (ex: /meudb/api/... -> meudb)
                var clientSlug = path.Split("/", StringSplitOptions.RemoveEmptyEntries)[0];

                // Busca a connection string dinâmica
                var connString = ConfigurationExtensions.GetClientConnectionString(clientSlug);

                // Configura o DbContext para SQL Server
                var optionsBuilder = new DbContextOptionsBuilder<GRCContext>();
                optionsBuilder.UseSqlServer(
                    connString,
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(); // Mantém retry
                        sqlOptions.MigrationsAssembly(typeof(GRCContext).Assembly.FullName);
                    }
                );

                // Só habilite logs sensíveis em DEV
                optionsBuilder.EnableSensitiveDataLogging();

                return new GRCContext(optionsBuilder.Options);
            });
        }
    }
}
