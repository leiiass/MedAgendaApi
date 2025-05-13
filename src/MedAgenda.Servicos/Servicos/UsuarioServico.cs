using MedAgenda.Dominio.Interfaces;
using MedAgenda.Dominio.Modelos;

namespace MedAgenda.Servicos.Servicos
{
    public class UsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Usuario Login(string email, string senha)
        {
            return _usuarioRepositorio.ObterPorEmailSenha(email, senha);
        }

        public void Registrar(Usuario usuario)
        {
            _usuarioRepositorio.Criar(usuario);
        }

        public Usuario ObterPorId(int id)
        {
            return _usuarioRepositorio.ObterPorId(id);
        }

        public void Atualizar(Usuario usuario)
        {
            _usuarioRepositorio.Atualizar(usuario);
        }
    }
}
