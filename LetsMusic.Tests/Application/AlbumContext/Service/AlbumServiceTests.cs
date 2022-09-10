using AutoMapper;
using FluentAssertions;
using Moq;
using LetsMusic.Application.AlbumContext.Dto;
using LetsMusic.Application.AlbumContext.Service;
using LetsMusic.CrossCutting.Exceptions;
using LetsMusic.Domain.AlbumContext;
using LetsMusic.Domain.AlbumContext.Repository;
using LetsMusic.Data;

namespace LetsMusic.Tests.Application.AlbumContext.Service
{
    public class AlbumServiceTests
    {
        private Mock<IAlbumRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IHttpClientFactory> _httpClientFactory;
        private Mock<IAzureBlobStorage> _storage;
        private AlbumService _service;

        public AlbumServiceTests()
        {
            _repositoryMock = new Mock<IAlbumRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new AlbumService(_repositoryMock.Object, _mapperMock.Object, _httpClientFactory.Object, _storage.Object);
        }

        [Fact]
        public async Task GetAll_deve_retornar_conforme_esperado()
        {
            var expected = new List<AlbumOutputDto>{
                AlbumMockHelper.MockAlbumOutputDto()
            };
            var albuns = new List<Album>{
                new Album(expected.ElementAt(0).Nome, new Musica { Id = Guid.NewGuid() })
            };

            _repositoryMock.Setup(mock => mock.GetAllWithIncludes()).ReturnsAsync(albuns);
            _mapperMock.Setup(mock => mock.Map<List<AlbumOutputDto>>(albuns)).Returns(expected);

            var actual = await _service.GetAll();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Create_deve_retornar_conforme_esperado()
        {
            var input = AlbumMockHelper.MockAlbumInputDto();
            var expected = AlbumMockHelper.MockAlbumOutputDto();
            var album = new Album(input.Nome, new Musica { Id = Guid.NewGuid() });

            _mapperMock.Setup(mock => mock.Map<Album>(input)).Returns(album);
            _mapperMock.Setup(mock => mock.Map<AlbumOutputDto>(album)).Returns(expected);

            var actual = await _service.Create(input);

            actual.Should().BeEquivalentTo(expected);

        }

        [Fact]
        public async Task Create_deve_chamar_repositorio_conforme_esperado()
        {
            var input = AlbumMockHelper.MockAlbumInputDto();
            var expected = AlbumMockHelper.MockAlbumOutputDto();
            var album = new Album(input.Nome, new Musica { Id = Guid.NewGuid() })
            {
                Id = expected.Id
            };

            _mapperMock.Setup(mock => mock.Map<Album>(input)).Returns(album);
            _mapperMock.Setup(mock => mock.Map<AlbumOutputDto>(album)).Returns(expected);

            _ = await _service.Create(input);

            _repositoryMock.Verify(mock => mock.Save(It.Is<Album>(a => a.Id == album.Id)), Times.Once);
        }

        [Fact]
        public async Task GetById_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            _repositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>())).ReturnsAsync((Album)null);

            Func<Task> act = () => _service.GetById(Guid.NewGuid());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Album não localizado");
        }

        [Fact]
        public async Task Update_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            _repositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>())).ReturnsAsync((Album)null);

            Func<Task> act = () => _service.Update(Guid.NewGuid(), AlbumMockHelper.MockAlbumInputDto());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Album não localizado");
        }

        [Fact]
        public async Task Delete_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            _repositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>())).ReturnsAsync((Album)null);

            Func<Task> act = () => _service.Delete(Guid.NewGuid());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Album não localizado");
        }
    }
}