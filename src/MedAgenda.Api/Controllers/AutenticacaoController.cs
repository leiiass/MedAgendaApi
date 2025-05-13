using MedAgenda.Api.Helpers;
using MedAgenda.Dominio.Modelos;
using MedAgenda.Servicos.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MedAgenda.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly UsuarioServico _usuarioServico;
        public AutenticacaoController(UsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario login)
        {
            var usuario = _usuarioServico.Login(login.Email, login.Password);
            if (usuario == null)
                return Unauthorized("Usuário ou senha inválidos");

            var token = TokenService.GerarToken(usuario);

            return Ok(new
            {
                token,
                user = new
                {
                    usuario.Id,
                    usuario.Nome,
                    usuario.Email,
                    usuario.Tipo,
                    usuario.PacienteId,
                    usuario.MedicoId
                }
            });
        }

        [HttpPost("register")]
        public IActionResult Registrar([FromBody] Usuario usuario)
        {
            _usuarioServico.Registrar(usuario);

            var token = TokenService.GerarToken(usuario);

            return Ok(new
            {
                token,
                user = new
                {
                    usuario.Id,
                    usuario.Nome,
                    usuario.Email
                }
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok(new { mensagem = "Logout efetuado com sucesso." });
        }

        [HttpGet("me")]
        public IActionResult Me()
        {
            var nome = User.Identity?.Name;
            var id = User.FindFirst("nameid")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            return Ok(new { id, nome, email });
        }
    }
}
