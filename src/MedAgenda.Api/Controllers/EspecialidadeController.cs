using MedAgenda.Dominio.Modelos;
using MedAgenda.Servicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace MedAgenda.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EspecialidadeController : ControllerBase
    {
        private readonly EspecialidadeServico _especialidadeServico;

        public EspecialidadeController(EspecialidadeServico especialidadeServico)
        {
            _especialidadeServico = especialidadeServico;
        }

        [HttpGet]
        public OkObjectResult ObterTodas()
        {
            var especialidades = _especialidadeServico.ObterTodas();
            return Ok(especialidades);
        }

        [HttpGet("{id}")]
        public OkObjectResult ObterPorId(int id)
        {
            var especialidade = _especialidadeServico.ObterPorId(id);
            return Ok(especialidade);
        }

        [HttpPost]
        public CreatedResult Criar([FromBody] Especialidade especialidade)
        {
            _especialidadeServico.Criar(especialidade);
            return Created();
        }

        [HttpPut("{id}")]
        public NoContentResult Editar(int id, [FromBody] Especialidade especialidade)
        {
            _especialidadeServico.Editar(id, especialidade);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public NoContentResult Remover(int id)
        {
            _especialidadeServico.Remover(id);
            return NoContent();
        }
    }
}
