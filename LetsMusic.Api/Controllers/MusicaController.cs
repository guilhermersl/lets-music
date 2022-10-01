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
    public class MusicaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MusicaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarTodas")]
        public async Task<IActionResult> ListarTodas()
        {
            var result = await _mediator.Send(new GetAllMusicaQuery());
            return Ok(result.Musicas);
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(MusicaInputDto dto)
        {
            var result = await _mediator.Send(new CreateMusicaCommand(dto));
            return Created($"{result.Musica.Id}", result.Musica);
        }

        [HttpGet("ListarPorId/{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            var result = await _mediator.Send(new GetByIdMusicaQuery(id));
            return Ok(result.Musica);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, MusicaInputDto dto)
        {
            var result = await _mediator.Send(new UpdateMusicaCommand(id, dto));
            return Ok(result.Musica);
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _mediator.Send(new DeleteMusicaCommand(id));
            return Ok("Exclusão realizada com sucesso!");
        }
    }
}