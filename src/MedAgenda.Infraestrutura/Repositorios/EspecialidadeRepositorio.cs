using MedAgenda.Dominio.Interfaces;
using MedAgenda.Dominio.Modelos;
using MedAgenda.Infraestrutura.BancoDeDados;

namespace MedAgenda.Infraestrutura.Repositorios
{
    public class EspecialidadeRepositorio : IEspecialidadeRepositorio
    {
        private readonly Context _context;

        public EspecialidadeRepositorio(Context context)
        {
            _context = context;
        }

        public List<Especialidade> ObterTodas()
        {
            return _context.Especialidades.ToList();
        }

        public Especialidade ObterPorId(int id)
        {
            return _context.Especialidades.Find(id);
        }

        public void Criar(Especialidade especialidade)
        {
            _context.Especialidades.Add(especialidade);
            _context.SaveChanges();
        }

        public void Editar(int id, Especialidade especialidade)
        {
            var existente = _context.Especialidades.Find(id);
            if (existente == null) return;

            existente.Nome = especialidade.Nome;
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var especialidade = _context.Especialidades.Find(id);
            if (especialidade == null) return;

            _context.Especialidades.Remove(especialidade);
            _context.SaveChanges();
        }
    }
}
