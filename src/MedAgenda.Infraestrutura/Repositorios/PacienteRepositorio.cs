using MedAgenda.Dominio.Interfaces;
using MedAgenda.Dominio.Modelos;
using MedAgenda.Infraestrutura.BancoDeDados;

namespace MedAgenda.Infraestrutura.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly Context _context;

        public PacienteRepositorio(Context context)
        {
            _context = context;
        }

        public List<Paciente> ObterTodos()
        {
            return _context.Pacientes.ToList();
        }

        public Paciente ObterPorId(int id)
        {
            return _context.Pacientes.Find(id);
        }

        public void Criar(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }

        public void Editar(int id, Paciente paciente)
        {
            var existente = _context.Pacientes.Find(id);
            if (existente == null) return;

            existente.Nome = paciente.Nome;
            existente.Email = paciente.Email;
            existente.Telefone = paciente.Telefone;
            existente.DataNascimento = paciente.DataNascimento;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null) return;

            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
        }
    }
}
