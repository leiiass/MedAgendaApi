using MedAgenda.Dominio.Modelos;
using MedAgenda.Servicos.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MedAgenda.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoServico _medicoServico;
        private readonly UsuarioServico _usuarioServico;
        private readonly EspecialidadeServico _especialidadeServico;
        public MedicoController(MedicoServico medicoServico, UsuarioServico usuarioServico, EspecialidadeServico especialidadeServico)
        {
            _medicoServico = medicoServico;
            _usuarioServico = usuarioServico;
            _especialidadeServico = especialidadeServico;
        }

        [HttpGet]
        public OkObjectResult ObterTodos()
        {
            var medicos = _medicoServico.ObterTodos();
            return Ok(medicos);
        }

        [Authorize]
        [HttpPost("completar-cadastro")]
        public IActionResult CompletarCadastro([FromBody] Medico medico)
        {
            var usuarioIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (usuarioIdClaim == null)
                return Unauthorized();

            int usuarioId = int.Parse(usuarioIdClaim);
            var usuario = _usuarioServico.ObterPorId(usuarioId);

            if (usuario == null || usuario.Tipo != TipoUsuario.Medico)
                return BadRequest("Usuário inválido ou não é um médico.");

            var especialidadeExistente = _especialidadeServico.ObterPorId(medico.Especialidade.Id);
            if (especialidadeExistente == null)
                return BadRequest("Especialidade não encontrada.");

            medico.EspecialidadeId = especialidadeExistente.Id;
            medico.Especialidade = null;

            _medicoServico.Criar(medico);

            usuario.MedicoId = medico.Id;
            _usuarioServico.Atualizar(usuario);

            return Ok(new { mensagem = "Cadastro de médico concluído com sucesso." });
        }

        [HttpGet("{id}")]
        public OkObjectResult ObterPorId(int id)
        {
            var medico = _medicoServico.ObterPorId(id);
            return Ok(medico);
        }

        [HttpPost]
        public CreatedResult Criar([FromBody] Medico medico)
        {
            _medicoServico.Criar(medico);
            return Created();
        }

        [HttpPut("{id}")]
        public NoContentResult Editar(int id, [FromBody] Medico medico)
        {
            _medicoServico.Editar(id, medico);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public NoContentResult Remover(int id)
        {
            _medicoServico.Remover(id);
            return NoContent();
        }
    }
}
