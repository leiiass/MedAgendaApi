using MedAgenda.Dominio.Interfaces;
using MedAgenda.Dominio.Modelos;
using MedAgenda.Infraestrutura.BancoDeDados;
using Microsoft.EntityFrameworkCore;

namespace MedAgenda.Infraestrutura.Repositorios
{
    public class MedicoRepositorio : IMedicoRepositorio
    {
        private readonly Context _context;

        public MedicoRepositorio(Context context)
        {
            _context = context;
        }

        public List<Medico> ObterTodos()
        {
            return _context.Medicos
                .Include(m => m.Especialidade)
                .ToList();
        }

        public Medico ObterPorId(int id)
        {
            return _context.Medicos
                .Include(m => m.Especialidade)
                .FirstOrDefault(m => m.Id == id);
        }

        public void Criar(Medico medico)
        {
            _context.Medicos.Add(medico);
            _context.SaveChanges();
        }

        public void Editar(int id, Medico medico)
        {
            var medicoExistente = _context.Medicos.Find(id);
            if (medicoExistente == null) return;

            medicoExistente.Nome = medico.Nome;
            medicoExistente.CRM = medico.CRM;
            medicoExistente.Email = medico.Email;
            medicoExistente.Telefone = medico.Telefone;
            medicoExistente.EspecialidadeId = medico.EspecialidadeId;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var medico = _context.Medicos.Find(id);
            if (medico == null) return;

            _context.Medicos.Remove(medico);
            _context.SaveChanges();
        }
    }
}
