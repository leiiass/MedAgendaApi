using MedAgenda.Dominio.Interfaces;
using MedAgenda.Infraestrutura.BancoDeDados;
using MedAgenda.Infraestrutura.Repositorios;
using MedAgenda.Servicos.Servicos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite("Data Source=medagenda.db"));

builder.Services.AddScoped<IMedicoRepositorio, MedicoRepositorio>();
builder.Services.AddScoped<IPacienteRepositorio, PacienteRepositorio>();
builder.Services.AddScoped<IEspecialidadeRepositorio, EspecialidadeRepositorio>();
builder.Services.AddScoped<IConsultaRepositorio, ConsultaRepositorio>();

builder.Services.AddScoped<MedicoServico>();
builder.Services.AddScoped<PacienteServico>();
builder.Services.AddScoped<EspecialidadeServico>();
builder.Services.AddScoped<ConsultaServico>();


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
