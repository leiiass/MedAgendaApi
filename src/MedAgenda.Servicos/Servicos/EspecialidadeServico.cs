using MedAgenda.Dominio.Interfaces;
using MedAgenda.Dominio.Modelos;

namespace MedAgenda.Servicos.Servicos
{
    public class EspecialidadeServico
    {
        private readonly IEspecialidadeRepositorio _especialidadeRepositorio;

        public EspecialidadeServico(IEspecialidadeRepositorio especialidadeRepositorio)
        {
            _especialidadeRepositorio = especialidadeRepositorio;
        }

        public List<Especialidade> ObterTodas()
        {
            return _especialidadeRepositorio.ObterTodas();
        }

        public Especialidade ObterPorId(int id)
        {
            return _especialidadeRepositorio.ObterPorId(id);
        }

        public void Criar(Especialidade especialidade)
        {
            _especialidadeRepositorio.Criar(especialidade);
        }

        public void Editar(int id, Especialidade especialidade)
        {
            _especialidadeRepositorio.Editar(id, especialidade);
        }

        public void Remover(int id)
        {
            _especialidadeRepositorio.Remover(id);
        }
    }
}
