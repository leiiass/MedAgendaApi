using MedAgenda.Dominio.Interfaces;
using MedAgenda.Dominio.Modelos;

namespace MedAgenda.Servicos.Servicos
{
    public class MedicoServico
    {
        private readonly IMedicoRepositorio _medicoRepositorio;

        public MedicoServico(IMedicoRepositorio medicoRepositorio)
        {
            _medicoRepositorio = medicoRepositorio;
        }

        public List<Medico> ObterTodos()
        {
            return _medicoRepositorio.ObterTodos();
        }

        public Medico ObterPorId(int id)
        {
            return _medicoRepositorio.ObterPorId(id);
        }

        public void Criar(Medico medico)
        {
            _medicoRepositorio.Criar(medico);
        }

        public void Editar(int id, Medico medico)
        {
            _medicoRepositorio.Editar(id, medico);
        }

        public void Remover(int id)
        {
            _medicoRepositorio.Remover(id);
        }
    }
}
