using MediatR;
using Microsoft.AspNetCore.Mvc;
using LetsMusic.Application.AlbumContext.Dto;
using LetsMusic.Application.AlbumContext.Handler.Command;
using LetsMusic.Application.AlbumContext.Handler.Query;
using Microsoft.AspNetCore.Authorization;

namespace LetsMusic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EstiloMusicalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstiloMusicalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            var result = await _mediator.Send(new GetAllEstiloMusicalQuery());
            return Ok(result.EstilosMusicais);
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(EstiloMusicalInputDto dto)
        {
            var result = await _mediator.Send(new CreateEstiloMusicalCommand(dto));
            return Created($"{result.EstiloMusical.Id}", result.EstiloMusical);
        }

        [HttpGet("ListarPorId/{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            var result = await _mediator.Send(new GetByIdEstiloMusicalQuery(id));
            return Ok(result.EstiloMusical);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, EstiloMusicalInputDto dto)
        {
            var result = await _mediator.Send(new UpdateEstiloMusicalCommand(id, dto));
            return Ok(result.EstiloMusical);
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _mediator.Send(new DeleteEstiloMusicalCommand(id));
            return Ok("Exclusão realizada com sucesso!");
        }
    }
}