using MedAgenda.Dominio.Interfaces;
using MedAgenda.Dominio.Modelos;
using MedAgenda.Infraestrutura.BancoDeDados;
using Microsoft.EntityFrameworkCore;

namespace MedAgenda.Infraestrutura.Repositorios
{
    public class ConsultaRepositorio : IConsultaRepositorio
    {
        private readonly Context _context;

        public ConsultaRepositorio(Context context)
        {
            _context = context;
        }

        public List<Consulta> ObterTodas()
        {
            return _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                    .Include(m => m.Especialidade)
                .ToList();
        }

        public List<Consulta> ObterPorPaciente(int pacienteId)
        {
            return _context.Consultas
                .Include(c => c.Medico)
                    .Include(m => m.Especialidade)
                .Where(c => c.PacienteId == pacienteId)
                .ToList();
        }

        public List<Consulta> ObterPorMedico(int medicoId)
        {
            return _context.Consultas
                .Include(c => c.Paciente)
                .Where(c => c.MedicoId == medicoId)
                .ToList();
        }

        public Consulta ObterPorId(int id)
        {
            return _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                    .Include(m => m.Especialidade)
                .FirstOrDefault(c => c.Id == id);
        }

        public void Criar(Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            _context.SaveChanges();
        }

        public void Editar(int id, Consulta consulta)
        {
            var existente = _context.Consultas.Find(id);
            if (existente == null) return;

            existente.PacienteId = consulta.PacienteId;
            existente.MedicoId = consulta.MedicoId;
            existente.DataHora = consulta.DataHora;
            existente.Status = consulta.Status;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var consulta = _context.Consultas.Find(id);
            if (consulta == null) return;

            _context.Consultas.Remove(consulta);
            _context.SaveChanges();
        }
    }
}
