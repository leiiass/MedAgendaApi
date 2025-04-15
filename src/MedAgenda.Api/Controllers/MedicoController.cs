using MedAgenda.Dominio.Modelos;
using MedAgenda.Servicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace MedAgenda.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoServico _medicoServico;
        public MedicoController(MedicoServico medicoServico)
        {
            _medicoServico = medicoServico;
        }

        [HttpGet]
        public OkObjectResult ObterTodos()
        {
            var medicos = _medicoServico.ObterTodos();
            return Ok(medicos);
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
