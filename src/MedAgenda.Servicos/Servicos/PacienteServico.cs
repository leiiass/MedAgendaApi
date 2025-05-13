using MedAgenda.Dominio.Interfaces;
using MedAgenda.Dominio.Modelos;

namespace MedAgenda.Servicos.Servicos
{
    public class PacienteServico
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;

        public PacienteServico(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }

        public List<Paciente> ObterTodos()
        {
            return _pacienteRepositorio.ObterTodos();
        }

        public Paciente ObterPorId(int id)
        {
            return _pacienteRepositorio.ObterPorId(id);
        }

        public void Criar(Paciente paciente)
        {
            _pacienteRepositorio.Criar(paciente);
        }

        public void Editar(int id, Paciente paciente)
        {
            _pacienteRepositorio.Editar(id, paciente);
        }

        public void Remover(int id)
        {
            _pacienteRepositorio.Remover(id);
        }
    }
}
