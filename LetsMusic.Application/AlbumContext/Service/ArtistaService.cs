using AutoMapper;
using LetsMusic.Application.AlbumContext.Dto;
using LetsMusic.CrossCutting.Exceptions;
using LetsMusic.Domain.AlbumContext;
using LetsMusic.Domain.AlbumContext.Repository;

namespace LetsMusic.Application.AlbumContext.Service
{
    public class ArtistaService : IArtistaService
    {
        private readonly IArtistaRepository _artistaRepository;
        private readonly IMapper _mapper;

        public ArtistaService(IArtistaRepository artistaRepository, IMapper mapper)
        {
            _artistaRepository = artistaRepository;
            _mapper = mapper;
        }

        public async Task<ArtistaOutputDto> Create(ArtistaInputDto dto)
        {
            var artista = _mapper.Map<Artista>(dto);

            await _artistaRepository.Save(artista);

            return _mapper.Map<ArtistaOutputDto>(artista);
        }

        public async Task<List<ArtistaOutputDto>> GetAll()
        {
            var result = await _artistaRepository.GetAll();

            return _mapper.Map<List<ArtistaOutputDto>>(result);
        }

        public async Task<ArtistaOutputDto> GetById(Guid id)
        {
            var entity = await _artistaRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Artista));

            return _mapper.Map<ArtistaOutputDto>(entity);
        }

        public async Task<ArtistaOutputDto> Update(Guid id, ArtistaInputDto dto)
        {
            var entity = await _artistaRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Artista));

            entity = _mapper.Map(dto, entity);
            await _artistaRepository.Update(entity);

            return _mapper.Map<ArtistaOutputDto>(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _artistaRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Artista));

            await _artistaRepository.Delete(entity);

            return true;
        }
    }
}