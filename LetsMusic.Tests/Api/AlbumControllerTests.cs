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
using LetsMusic.Tests.Application.AlbumContext;
using LetsMusic.Data;

namespace LetsMusic.Tests.Api
{
    public class AlbumControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        //private Mock<IHttpClientFactory> _httpClientFactory;
        //private Mock<IAzureBlobStorage> _storage;
        private AlbumController _controller;

        public AlbumControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new AlbumController(_mediatorMock.Object/*, _httpClientFactory.Object, _storage.Object*/);
        }

        [Fact]
        public async Task ListarTodos_deve_retornar_conforme_esperado()
        {
            var expected = new List<AlbumOutputDto>
            {
                AlbumMockHelper.MockAlbumOutputDto(),
                AlbumMockHelper.MockAlbumOutputDto()
            };

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<GetAllAlbumQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetAllAlbumQueryResponse(expected));

            var result = await _controller.ListarTodos();

            var actual = result as OkObjectResult;

            actual.StatusCode.Should().Be(200);
            actual.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Criar_deve_retornar_conforme_esperado()
        {
            var expected = AlbumMockHelper.MockAlbumOutputDto();
            var input = AlbumMockHelper.MockAlbumInputDto();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<CreateAlbumCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateAlbumCommandResponse(expected));

            var result = await _controller.Criar(input);

            var actual = result as CreatedResult;

            actual.StatusCode.Should().Be(201);
            actual.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Criar_deve_chamar_mediatr_conforme_esperado()
        {
            var input = AlbumMockHelper.MockAlbumInputDto();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<CreateAlbumCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateAlbumCommandResponse(AlbumMockHelper.MockAlbumOutputDto()));

            _ = await _controller.Criar(input);

            _mediatorMock.Verify(mock => mock.Send(It.Is<CreateAlbumCommand>(command => command.Album == input), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ListarPorId_deve_retornar_conforme_esperado()
        {
            var expected = AlbumMockHelper.MockAlbumOutputDto();
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<GetByIdAlbumQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetByIdAlbumQueryResponse(expected));

            var result = await _controller.ListarPorId(id);

            var actual = result as OkObjectResult;

            actual.StatusCode.Should().Be(200);
            actual.Value.Should().Be(expected);
        }

        [Fact]
        public async Task ListarPorId_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            var expectedException = new IdNotFoundException(nameof(Album));

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<GetByIdAlbumQuery>(), It.IsAny<CancellationToken>())).ThrowsAsync(expectedException);

            Func<Task> act = () => _controller.ListarPorId(Guid.NewGuid());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Album não localizado");
        }

        [Fact]
        public async Task ListarPorId_deve_chamar_mediatr_conforme_esperado()
        {
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<GetByIdAlbumQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetByIdAlbumQueryResponse(AlbumMockHelper.MockAlbumOutputDto()));

            _ = await _controller.ListarPorId(id);

            _mediatorMock.Verify(mock => mock.Send(It.Is<GetByIdAlbumQuery>(command => command.Id == id), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Atualizar_deve_retornar_conforme_esperado()
        {
            var expected = AlbumMockHelper.MockAlbumOutputDto();
            var input = AlbumMockHelper.MockAlbumInputDto();
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<UpdateAlbumCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new UpdateAlbumCommandResponse(expected));

            var result = await _controller.Atualizar(id, input);

            var actual = result as OkObjectResult;

            actual.StatusCode.Should().Be(200);
            actual.Value.Should().Be(expected);
        }

        [Fact]
        public async Task Atualizar_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            var expectedException = new IdNotFoundException(nameof(Album));

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<UpdateAlbumCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(expectedException);

            Func<Task> act = () => _controller.Atualizar(Guid.NewGuid(), AlbumMockHelper.MockAlbumInputDto());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Album não localizado");
        }

        [Fact]
        public async Task Atualizar_deve_chamar_mediatr_conforme_esperado()
        {
            var input = AlbumMockHelper.MockAlbumInputDto();
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<UpdateAlbumCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new UpdateAlbumCommandResponse(AlbumMockHelper.MockAlbumOutputDto()));

            _ = await _controller.Atualizar(id, input);

            _mediatorMock.Verify(mock => mock.Send(It.Is<UpdateAlbumCommand>(command => command.Id == id && command.Album == input), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Excluir_deve_retornar_conforme_esperado()
        {
            var expected = "Exclusão realizada com sucesso!";
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<DeleteAlbumCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var result = await _controller.Excluir(id);

            var actual = result as OkObjectResult;

            actual.StatusCode.Should().Be(200);
            actual.Value.Should().Be(expected);
        }

        [Fact]
        public async Task Excluir_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            var expectedException = new IdNotFoundException(nameof(Album));

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<DeleteAlbumCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(expectedException);

            Func<Task> act = () => _controller.Excluir(Guid.NewGuid());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Album não localizado");
        }

        [Fact]
        public async Task Excluir_deve_chamar_mediatr_conforme_esperado()
        {
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<DeleteAlbumCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            _ = await _controller.Excluir(id);

            _mediatorMock.Verify(mock => mock.Send(It.Is<DeleteAlbumCommand>(command => command.Id == id), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}