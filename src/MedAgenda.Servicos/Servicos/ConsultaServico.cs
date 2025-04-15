using MedAgenda.Dominio.Interfaces;
using MedAgenda.Dominio.Modelos;

namespace MedAgenda.Servicos.Servicos
{
    public class ConsultaServico
    {
        private readonly IConsultaRepositorio _consultaRepositorio;
        public ConsultaServico(IConsultaRepositorio consultaRepositorio)
        {
            _consultaRepositorio = consultaRepositorio;
        }

        public List<Consulta> ObterTodos()
        {
            return _consultaRepositorio.ObterTodas();
        }

        public Consulta ObterPorId(int id)
        {
            return _consultaRepositorio.ObterPorId(id);
        }

        public void Criar(Consulta consulta)
        {
            _consultaRepositorio.Criar(consulta);
        }

        public void Editar(int id, Consulta consulta)
        {
            _consultaRepositorio.Editar(id, consulta);
        }

        public void Remover(int id)
        {
            _consultaRepositorio.Remover(id);
        }
    }
}
