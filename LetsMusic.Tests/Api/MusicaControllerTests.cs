using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using LetsMusic.Api.Controllers;
using LetsMusic.Application.AlbumContext.Dto;
using LetsMusic.Application.AlbumContext.Handler.Command;
using LetsMusic.Application.AlbumContext.Handler.Query;
using LetsMusic.CrossCutting.Exceptions;
using LetsMusic.Domain.AlbumContext;
using LetsMusic.Tests.Application.MusicaContext;

namespace LetsMusic.Tests.Api
{
    public class MusicaControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private MusicaController _controller;

        public MusicaControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new MusicaController(_mediatorMock.Object);
        }

        [Fact]
        public async Task ListarTodos_deve_retornar_conforme_esperado()
        {
            var expected = new List<MusicaOutputDto>
            {
                MusicaMockHelper.MockMusicaOutputDto(),
                MusicaMockHelper.MockMusicaOutputDto()
            };

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<GetAllMusicaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetAllMusicaQueryResponse(expected));

            var result = await _controller.ListarTodas();

            var actual = result as OkObjectResult;

            actual.StatusCode.Should().Be(200);
            actual.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Criar_deve_retornar_conforme_esperado()
        {
            var expected = MusicaMockHelper.MockMusicaOutputDto();
            var input = MusicaMockHelper.MockMusicInputDto();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<CreateMusicaCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateMusicaCommandResponse(expected));

            var result = await _controller.Criar(input);

            var actual = result as CreatedResult;

            actual.StatusCode.Should().Be(201);
            actual.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Criar_deve_chamar_mediatr_conforme_esperado()
        {
            var input = MusicaMockHelper.MockMusicInputDto();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<CreateMusicaCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateMusicaCommandResponse(MusicaMockHelper.MockMusicaOutputDto()));

            _ = await _controller.Criar(input);

            _mediatorMock.Verify(mock => mock.Send(It.Is<CreateMusicaCommand>(command => command.Musica == input), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ListarPorId_deve_retornar_conforme_esperado()
        {
            var expected = MusicaMockHelper.MockMusicaOutputDto();
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<GetByIdMusicaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetByIdMusicaQueryResponse(expected));

            var result = await _controller.ListarPorId(id);

            var actual = result as OkObjectResult;

            actual.StatusCode.Should().Be(200);
            actual.Value.Should().Be(expected);
        }

        [Fact]
        public async Task ListarPorId_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            var expectedException = new IdNotFoundException(nameof(Musica));

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<GetByIdMusicaQuery>(), It.IsAny<CancellationToken>())).ThrowsAsync(expectedException);

            Func<Task> act = () => _controller.ListarPorId(Guid.NewGuid());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Musica não localizado");
        }

        [Fact]
        public async Task ListarPorId_deve_chamar_mediatr_conforme_esperado()
        {
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<GetByIdMusicaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetByIdMusicaQueryResponse(MusicaMockHelper.MockMusicaOutputDto()));

            _ = await _controller.ListarPorId(id);

            _mediatorMock.Verify(mock => mock.Send(It.Is<GetByIdMusicaQuery>(command => command.Id == id), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Atualizar_deve_retornar_conforme_esperado()
        {
            var expected = MusicaMockHelper.MockMusicaOutputDto();
            var input = MusicaMockHelper.MockMusicInputDto();
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<UpdateMusicaCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new UpdateMusicaCommandResponse(expected));

            var result = await _controller.Atualizar(id, input);

            var actual = result as OkObjectResult;

            actual.StatusCode.Should().Be(200);
            actual.Value.Should().Be(expected);
        }

        [Fact]
        public async Task Atualizar_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            var expectedException = new IdNotFoundException(nameof(Musica));

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<UpdateMusicaCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(expectedException);

            Func<Task> act = () => _controller.Atualizar(Guid.NewGuid(), MusicaMockHelper.MockMusicInputDto());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Musica não localizado");
        }

        [Fact]
        public async Task Atualizar_deve_chamar_mediatr_conforme_esperado()
        {
            var input = MusicaMockHelper.MockMusicInputDto();
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<UpdateMusicaCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new UpdateMusicaCommandResponse(MusicaMockHelper.MockMusicaOutputDto()));

            _ = await _controller.Atualizar(id, input);

            _mediatorMock.Verify(mock => mock.Send(It.Is<UpdateMusicaCommand>(command => command.Id == id && command.Musica == input), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Excluir_deve_retornar_conforme_esperado()
        {
            var expected = "Exclusão realizada com sucesso!";
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<DeleteMusicaCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var result = await _controller.Excluir(id);

            var actual = result as OkObjectResult;

            actual.StatusCode.Should().Be(200);
            actual.Value.Should().Be(expected);
        }

        [Fact]
        public async Task Excluir_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            var expectedException = new IdNotFoundException(nameof(Musica));

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<DeleteMusicaCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(expectedException);

            Func<Task> act = () => _controller.Excluir(Guid.NewGuid());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Musica não localizado");
        }

        [Fact]
        public async Task Excluir_deve_chamar_mediatr_conforme_esperado()
        {
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<DeleteMusicaCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            _ = await _controller.Excluir(id);

            _mediatorMock.Verify(mock => mock.Send(It.Is<DeleteMusicaCommand>(command => command.Id == id), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}