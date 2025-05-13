using MedAgenda.Dominio.Modelos;
using MedAgenda.Servicos.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MedAgenda.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteServico _pacienteServico;
        private readonly UsuarioServico _usuarioServico;

        public PacienteController(PacienteServico pacienteServico, UsuarioServico usuarioServico)
        {
            _pacienteServico = pacienteServico;
            _usuarioServico = usuarioServico;
        }

        [Authorize]
        [HttpPost("completar-cadastro")]
        public IActionResult CompletarCadastro([FromBody] Paciente paciente)
        {
            var usuarioIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (usuarioIdClaim == null)
                return Unauthorized();

            int usuarioId = int.Parse(usuarioIdClaim);
            var usuario = _usuarioServico.ObterPorId(usuarioId);

            if (usuario == null || usuario.Tipo != TipoUsuario.Paciente)
                return BadRequest("Usuário inválido ou não é um paciente.");

            _pacienteServico.Criar(paciente);

            usuario.PacienteId = paciente.Id;
            _usuarioServico.Atualizar(usuario); 

            return Ok(new { mensagem = "Cadastro de paciente concluído com sucesso." });
        }

        [HttpGet]
        public OkObjectResult ObterTodos()
        {
            var pacientes = _pacienteServico.ObterTodos();
            return Ok(pacientes);
        }

        [Authorize]
        [HttpGet("{id}")]
        public OkObjectResult ObterPorId(int id)
        {
            var paciente = _pacienteServico.ObterPorId(id);
            return Ok(paciente);
        }

        [HttpPost]
        public CreatedResult Criar([FromBody] Paciente paciente)
        {
            _pacienteServico.Criar(paciente);
            return Created();
        }

        [HttpPut("{id}")]
        public NoContentResult Editar(int id, [FromBody] Paciente paciente)
        {
            _pacienteServico.Editar(id, paciente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public NoContentResult Remover(int id)
        {
            _pacienteServico.Remover(id);
            return NoContent();
        }
    }
}
