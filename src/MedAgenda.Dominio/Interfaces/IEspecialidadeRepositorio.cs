using MedAgenda.Dominio.Modelos;

namespace MedAgenda.Dominio.Interfaces
{
    public interface IEspecialidadeRepositorio
    {
        List<Especialidade> ObterTodas();
        Especialidade ObterPorId(int id);
        void Criar(Especialidade especialidade);
        void Editar(int id, Especialidade especialidade);
        void Remover(int id);
    }
}