using MediatR;
using Microsoft.AspNetCore.Mvc;
using LetsMusic.Application.AlbumContext.Dto;
using LetsMusic.Application.AlbumContext.Handler.Command;
using LetsMusic.Application.AlbumContext.Handler.Query;
using LetsMusic.Data;
using Microsoft.AspNetCore.Authorization;

namespace LetsMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private readonly IHttpClientFactory _httpClientFactory;
        //private readonly IAzureBlobStorage _storage;

        public AlbumController(IMediator mediator/*, IHttpClientFactory httpClientFactory, IAzureBlobStorage storage*/)
        {
            _mediator = mediator;
            //_httpClientFactory = httpClientFactory;
            //_storage = storage;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var resut = await _mediator.Send(new GetAllAlbumQuery());
            return Ok(resut.Albums);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(AlbumInputDto dto)
        {
            var result = await _mediator.Send(new CreateAlbumCommand(dto));
            return Created($"{result.Album.Id}", result.Album);
        }

        [HttpGet("ListarPorId/{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            var result = await _mediator.Send(new GetByIdAlbumQuery(id));
            return Ok(result.Album);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, AlbumInputDto dto)
        {
            var result = await _mediator.Send(new UpdateAlbumCommand(id, dto));
            return Ok(result.Album);
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _mediator.Send(new DeleteAlbumCommand(id));
            return Ok("Exclus?o realizada com sucesso!");
        }
    }
}