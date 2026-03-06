using Microsoft.EntityFrameworkCore;
using Royal_Games.Contexts;
using Royal_Games.Repositories;
using Royal_Games.Interface;
using Royal_Games.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// 1?? Registrar o DbContext
builder.Services.AddDbContext<RoyalGamesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 2?? Registrar Repositories e Services
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<GeneroService>();

builder.Services.AddScoped<IPlataformaRepository, PlataformaRepository>();
builder.Services.AddScoped<PlataformaService>();


builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddScoped<IClassificacaoRepository, ClassificacaoRepository>();
builder.Services.AddScoped<ClassificacaoService>();



// 3?? Outros serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4?? Middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();