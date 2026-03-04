using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Royal_Games.Application.Services;
using Royal_Games.Contexts;
using Royal_Games.Interface;
using Royal_Games.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Banco de dados
builder.Services.AddDbContext<RoyalGamesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Usuarios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();

// Genero
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<GeneroService>();

// Plataforma
builder.Services.AddScoped<IPlataformaRepository, PlataformaRepository>();
builder.Services.AddScoped<PlataformaService>();

// Classificacao Indicativa
builder.Services.AddScoped<IClassificacaoRepository, ClassificacaoRepository>();
builder.Services.AddScoped<ClassificacaoService>();

// Genero
builder.Services.AddScoped<IGeneroRepository, IGeneroRepository>();
builder.Services.AddScoped<GeneroService>();

// Plataforma
builder.Services.AddScoped<IPlataformaRepository, IPlataformaRepository>();
builder.Services.AddScoped<PlataformaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
