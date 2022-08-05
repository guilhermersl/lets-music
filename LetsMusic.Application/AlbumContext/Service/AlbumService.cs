using AutoMapper;
using LetsMusic.Application.AlbumContext.Dto;
using LetsMusic.CrossCutting.Exceptions;
using LetsMusic.Domain.AlbumContext;
using LetsMusic.Domain.AlbumContext.Repository;

namespace LetsMusic.Application.AlbumContext.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task<AlbumOutputDto> Create(AlbumInputDto dto)
        {
            var album = _mapper.Map<Album>(dto);

            await _albumRepository.Save(album);

            return _mapper.Map<AlbumOutputDto>(album);
        }

        public async Task<List<AlbumOutputDto>> GetAll()
        {
            var result = await _albumRepository.GetAllWithIncludes();

            return _mapper.Map<List<AlbumOutputDto>>(result);
        }

        public async Task<AlbumOutputDto> GetById(Guid id)
        {
            var entity = await _albumRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Album));

            return _mapper.Map<AlbumOutputDto>(entity);
        }

        public async Task<AlbumOutputDto> Update(Guid id, AlbumInputDto dto)
        {
            var entity = await _albumRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Album));

            entity = _mapper.Map(dto, entity);
            await _albumRepository.Update(entity);

            return _mapper.Map<AlbumOutputDto>(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _albumRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Album));

            await _albumRepository.Delete(entity);

            return true;
        }

    }
}