using AutoMapper;
using FluentAssertions;
using Moq;
using LetsMusic.Application.AlbumContext.Dto;
using LetsMusic.Application.AlbumContext.Service;
using LetsMusic.CrossCutting.Exceptions;
using LetsMusic.Domain.AlbumContext;
using LetsMusic.Domain.AlbumContext.Repository;

namespace LetsMusic.Tests.Application.MusicaContext.Service
{
    public class MusicaServiceTests
    {
        private Mock<IMusicaRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private MusicaService _service;

        public MusicaServiceTests()
        {
            _repositoryMock = new Mock<IMusicaRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new MusicaService(_repositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAll_deve_retornar_conforme_esperado()
        {
            var expected = new List<MusicaOutputDto>{
                MusicaMockHelper.MockMusicaOutputDto()
            };
            var albuns = new List<Musica>{
                new Musica()
            };

            _repositoryMock.Setup(mock => mock.GetAllWithIncludes()).ReturnsAsync(albuns);
            _mapperMock.Setup(mock => mock.Map<List<MusicaOutputDto>>(albuns)).Returns(expected);

            var actual = await _service.GetAll();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Create_deve_retornar_conforme_esperado()
        {
            var input = MusicaMockHelper.MockMusicInputDto();
            var expected = MusicaMockHelper.MockMusicaOutputDto();
            var Musica = new Musica();

            _mapperMock.Setup(mock => mock.Map<Musica>(input)).Returns(Musica);
            _mapperMock.Setup(mock => mock.Map<MusicaOutputDto>(Musica)).Returns(expected);

            var actual = await _service.Create(input);

            actual.Should().BeEquivalentTo(expected);

        }

        [Fact]
        public async Task Create_deve_chamar_repositorio_conforme_esperado()
        {
            var input = MusicaMockHelper.MockMusicInputDto();
            var expected = MusicaMockHelper.MockMusicaOutputDto();
            var Musica = new Musica()
            {
                Id = expected.Id
            };

            _mapperMock.Setup(mock => mock.Map<Musica>(input)).Returns(Musica);
            _mapperMock.Setup(mock => mock.Map<MusicaOutputDto>(Musica)).Returns(expected);

            _ = await _service.Create(input);

            _repositoryMock.Verify(mock => mock.Save(It.Is<Musica>(a => a.Id == Musica.Id)), Times.Once);
        }

        [Fact]
        public async Task GetById_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            _repositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>())).ReturnsAsync((Musica)null);

            Func<Task> act = () => _service.GetById(Guid.NewGuid());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Musica não localizado");
        }

        [Fact]
        public async Task Update_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            _repositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>())).ReturnsAsync((Musica)null);

            Func<Task> act = () => _service.Update(Guid.NewGuid(), MusicaMockHelper.MockMusicInputDto());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Musica não localizado");
        }

        [Fact]
        public async Task Delete_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            _repositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>())).ReturnsAsync((Musica)null);

            Func<Task> act = () => _service.Delete(Guid.NewGuid());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Musica não localizado");
        }
    }
}