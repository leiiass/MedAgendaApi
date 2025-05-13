using MedAgenda.Dominio.Modelos;
using MedAgenda.Servicos.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedAgenda.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaServico _consultaServico;

        public ConsultaController(ConsultaServico consultaServico)
        {
            _consultaServico = consultaServico;
        }

        [HttpGet]
        public OkObjectResult ObterTodos()
        {
            var consultas = _consultaServico.ObterTodos();
            return Ok(consultas);
        }

        [HttpGet("por-paciente/{pacienteId}")]
        public IActionResult ObterPorPaciente(int pacienteId)
        {
            var consultas = _consultaServico.ObterPorPaciente(pacienteId);
            return Ok(consultas);
        }

        [HttpGet("por-medico/{medicoId}")]
        public IActionResult ObterPorMedico(int medicoId)
        {
            var consultas = _consultaServico.ObterPorMedico(medicoId);
            return Ok(consultas);
        }

        [HttpGet("{id}")]
        public OkObjectResult ObterPorId(int id)
        {
            var consulta = _consultaServico.ObterPorId(id);
            return Ok(consulta);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Criar([FromBody] Consulta consulta)
        {
            _consultaServico.Criar(consulta);
            return CreatedAtAction(nameof(ObterPorId), new { id = consulta.Id }, consulta);
        }

        [HttpPut("{id}")]
        public NoContentResult Editar(int id, [FromBody] Consulta consulta)
        {
            _consultaServico.Editar(id, consulta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public NoContentResult Remover(int id)
        {
            _consultaServico.Remover(id);
            return NoContent();
        }
    }
}
