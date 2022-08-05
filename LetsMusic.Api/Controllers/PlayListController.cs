using MediatR;
using Microsoft.AspNetCore.Mvc;
using LetsMusic.Application.ContaContext.Dto;
using LetsMusic.Application.ContaContext.Handler.Command;
using LetsMusic.Application.ContaContext.Handler.Query;

namespace LetsMusic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarTodas")]
        public async Task<IActionResult> ListarTodas()
        {
            var result = await _mediator.Send(new GetAllPlayListQuery());
            return Ok(result.PlayLists);
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(PlayListInputDto dto)
        {
            var result = await _mediator.Send(new CreatePlayListCommand(dto));
            return Created($"{result.PlayList.Id}", result.PlayList);
        }

        [HttpGet("ListarPorId/{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            var result = await _mediator.Send(new GetByIdPlayListQuery(id));
            return Ok(result.PlayList);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, PlayListInputDto dto)
        {
            var result = await _mediator.Send(new UpdatePlayListCommand(id, dto));
            return Ok(result.PlayList);
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _mediator.Send(new DeletePlayListCommand(id));
            return Ok("Exclusão realizada com sucesso!");
        }
    }
}