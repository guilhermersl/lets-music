using MediatR;
using Microsoft.AspNetCore.Mvc;
using LetsMusic.Application.AlbumContext.Dto;
using LetsMusic.Application.AlbumContext.Handler.Command;
using LetsMusic.Application.AlbumContext.Handler.Query;

namespace LetsMusic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArtistaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            var result = await _mediator.Send(new GetAllArtistaQuery());
            return Ok(result.Artistas);
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(ArtistaInputDto dto)
        {
            var result = await _mediator.Send(new CreateArtistaCommand(dto));
            return Created($"{result.Artista.Id}", result.Artista);
        }

        [HttpGet("ListarPorId/{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            var result = await _mediator.Send(new GetByIdArtistaQuery(id));
            return Ok(result.Artista);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, ArtistaInputDto dto)
        {
            var result = await _mediator.Send(new UpdateArtistaCommand(id, dto));
            return Ok(result.Artista);
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _mediator.Send(new DeleteArtistaCommand(id));
            return Ok("Exclusão realizada com sucesso!");
        }
    }
}