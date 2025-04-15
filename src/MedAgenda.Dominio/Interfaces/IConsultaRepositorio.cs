using MedAgenda.Dominio.Modelos;

namespace MedAgenda.Dominio.Interfaces
{
    public interface IConsultaRepositorio
    {
        List<Consulta> ObterTodas();
        Consulta ObterPorId(int id);
        void Criar(Consulta consulta);
        void Editar(int id, Consulta consulta);
        void Remover(int id);
    }
}
