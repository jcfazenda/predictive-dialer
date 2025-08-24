using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Domain.Tenant;  // Para AddCustomerDbContext
using Services.Domain.Repository.Interface.Usuario;
using Services.Domain.Repository.Queryable.Usuario;

var builder = WebApplication.CreateBuilder(args);

// Injeção de HttpContextAccessor (necessário para Services capturar tenant da URL)
builder.Services.AddHttpContextAccessor();

// Adiciona controllers
builder.Services.AddControllers();

// Configura política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configura DbContext dinâmico via tenant
builder.Services.AddCustomerDbContext(); // Scoped por request, thread-safe

// Registra repositórios como Scoped (para usar o DbContext corretamente)
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}

app.UseHttpsRedirection();

// Habilita CORS antes de usar autorização
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

// Registro do tipo para o endpoint de exemplo
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
