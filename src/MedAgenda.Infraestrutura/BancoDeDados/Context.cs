using MedAgenda.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MedAgenda.Infraestrutura.BancoDeDados
{
    public class Context : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}
