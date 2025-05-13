using MedAgenda.Dominio.Modelos;

namespace MedAgenda.Dominio.Interfaces
{
    public interface IPacienteRepositorio
    {
        List<Paciente> ObterTodos();
        Paciente ObterPorId(int id);
        void Criar(Paciente paciente);
        void Editar(int id, Paciente paciente);
        void Remover(int id);
    }
}
