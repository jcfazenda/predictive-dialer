using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Domain.Tenant;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Serviços essenciais
builder.Services.AddHttpContextAccessor();

// Adiciona controllers e configura o JsonSerializer para ignorar ciclos
builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.WriteIndented = true; // opcional: JSON mais legível
    });

// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Configura DbContext dinâmico via tenant (Scoped por request, thread-safe)
builder.Services.AddCustomerDbContext();

// Repositórios
builder.Services.AddScoped<Services.Domain.Repository.Interface.Campanha.ICampanhasRepository,
                           Services.Domain.Repository.Queryable.Campanha.CampanhasRepository>();

builder.Services.AddScoped<Services.Domain.Repository.Interface.Usuario.IUsuariosRepository, 
                           Services.Domain.Repository.Queryable.Usuario.UsuariosRepository>();

builder.Services.AddSingleton<Services.Domain.Discadores.Twillio.TwillioDial>();


// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------------------------
// Construção do app
// ---------------------------

var app = builder.Build();

// ---------------------------
// Pipeline HTTP
// ---------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"));
}

app.UseHttpsRedirection();

app.UseRouting();          // Importante antes de CORS e Authorization
app.UseCors("CorsPolicy");

app.UseAuthorization();
app.MapControllers();
app.Run();
