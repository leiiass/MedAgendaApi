using MedAgenda.Dominio.Modelos;

namespace MedAgenda.Dominio.Interfaces
{
    public interface IMedicoRepositorio
    {
        List<Medico> ObterTodos();
        Medico ObterPorId(int id);
        void Criar(Medico medico);
        void Editar(int id, Medico medico);
        void Remover(int id);
    }
}
