using MedAgenda.Dominio.Modelos;
using MedAgenda.Servicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace MedAgenda.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteServico _pacienteServico;

        public PacienteController(PacienteServico pacienteServico)
        {
            _pacienteServico = pacienteServico;
        }

        [HttpGet]
        public OkObjectResult ObterTodos()
        {
            var pacientes = _pacienteServico.ObterTodos();
            return Ok(pacientes);
        }

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
