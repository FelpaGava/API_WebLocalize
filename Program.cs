using API_Teste.Data;
using API_Teste.Services.Cidades;
using API_Teste.Services.Estados;
using API_Teste.Services.Local;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEstadosInterface, EstadosServices>();
builder.Services.AddScoped<ILocaisInterface, LocaisServices>();
builder.Services.AddScoped<ICidadesInterface, CidadesServices>();

builder.Services.AddDbContext<AppDbContext>(options => 
{ 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
