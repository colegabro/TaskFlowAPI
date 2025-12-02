using Microsoft.EntityFrameworkCore;
using TaskFlow.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.

builder.Services.AddControllers();
// Aprenda mais sobre configurar Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- CONFIGURAÇÃO DO BANCO DE DADOS (Obrigatória para o EF Core) ---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// ------------------------------------------------------------------

var app = builder.Build();

// Configurar o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();