using MedAgenda.Dominio.Modelos;

namespace MedAgenda.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario ObterPorEmailSenha(string email, string senha);
        void Criar(Usuario usuario);
        Usuario ObterPorId(int id);
        void Atualizar(Usuario usuario);
    }
}
