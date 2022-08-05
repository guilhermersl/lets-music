using FluentAssertions;
using Moq;
using LetsMusic.Application.AlbumContext.Dto;
using LetsMusic.Application.AlbumContext.Handler;
using LetsMusic.Application.AlbumContext.Handler.Command;
using LetsMusic.Application.AlbumContext.Handler.Query;
using LetsMusic.Application.AlbumContext.Service;
using LetsMusic.Application.MusicaContext.Handler;

namespace LetsMusic.Tests.Application.MusicaContext.Handler
{
    public class MusicaHandlerTests
    {
        private Mock<IMusicaService> _serviceMock;
        private MusicaHandler _handler;

        public MusicaHandlerTests()
        {
            _serviceMock = new Mock<IMusicaService>();
            _handler = new MusicaHandler(_serviceMock.Object);
        }

        [Fact]
        public async Task GetAllMusicaQuery_Handle_deve_retornar_conforme_esperado()
        {
            var albuns = new List<MusicaOutputDto>
            {
                MusicaMockHelper.MockMusicaOutputDto(),
                MusicaMockHelper.MockMusicaOutputDto(),
                MusicaMockHelper.MockMusicaOutputDto()
            };
            var expected = new GetAllMusicaQueryResponse(albuns);

            _serviceMock.Setup(mock => mock.GetAll()).ReturnsAsync(albuns);

            var actual = await _handler.Handle(new GetAllMusicaQuery(), new CancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task CreateMusicaCommand_Handle_deve_retornar_conforme_esperado()
        {
            var Musica = MusicaMockHelper.MockMusicaOutputDto();

            var expected = new CreateMusicaCommandResponse(Musica);

            var input = MusicaMockHelper.MockMusicInputDto();
            _serviceMock.Setup(mock => mock.Create(input)).ReturnsAsync(Musica);

            var actual = await _handler.Handle(new CreateMusicaCommand(input), new CancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetByIdMusicaQuery_Handle_deve_retornar_conforme_esperado()
        {
            var id = Guid.NewGuid();
            var Musica = MusicaMockHelper.MockMusicaOutputDto();
            var expected = new GetByIdMusicaQueryResponse(Musica);

            _serviceMock.Setup(mock => mock.GetById(id)).ReturnsAsync(Musica);

            var actual = await _handler.Handle(new GetByIdMusicaQuery(id), new CancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task UpdateMusicaCommand_Handle_deve_retornar_conforme_esperado()
        {
            var id = Guid.NewGuid();
            var input = MusicaMockHelper.MockMusicInputDto();

            var Musica = MusicaMockHelper.MockMusicaOutputDto();
            var expected = new UpdateMusicaCommandResponse(Musica);

            _serviceMock.Setup(mock => mock.Update(id, input)).ReturnsAsync(Musica);

            var actual = await _handler.Handle(new UpdateMusicaCommand(id, input), new CancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task DeleteMusicaCommand_Handle_deve_retornar_conforme_esperado()
        {
            var id = Guid.NewGuid();
            var expected = true;

            _serviceMock.Setup(mock => mock.Delete(id)).ReturnsAsync(expected);

            var actual = await _handler.Handle(new DeleteMusicaCommand(id), new CancellationToken());

            actual.Should().Be(expected);
        }
    }
}