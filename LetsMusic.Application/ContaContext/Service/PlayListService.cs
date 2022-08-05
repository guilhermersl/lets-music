using AutoMapper;
using LetsMusic.Application.ContaContext.Dto;
using LetsMusic.CrossCutting.Exceptions;
using LetsMusic.Domain.ContaContext;
using LetsMusic.Domain.ContaContext.Repository;

namespace LetsMusic.Application.ContaContext.Service
{
    public class PlayListService : IPlayListService
    {
        private readonly IPlayListRepository _playlistRepository;
        private readonly IMapper _mapper;

        public PlayListService(IPlayListRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }

        public async Task<PlayListOutputDto> Create(PlayListInputDto dto)
        {
            var playlist = _mapper.Map<PlayList>(dto);

            await _playlistRepository.Save(playlist);

            return _mapper.Map<PlayListOutputDto>(playlist);
        }

        public async Task<List<PlayListOutputDto>> GetAll()
        {
            var result = await _playlistRepository.GetAll();

            return _mapper.Map<List<PlayListOutputDto>>(result);
        }

        public async Task<PlayListOutputDto> GetById(Guid id)
        {
            var entity = await _playlistRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(PlayList));

            return _mapper.Map<PlayListOutputDto>(entity);
        }

        public async Task<PlayListOutputDto> Update(Guid id, PlayListInputDto dto)
        {
            var entity = await _playlistRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(PlayList));

            entity = _mapper.Map(dto, entity);
            await _playlistRepository.Update(entity);

            return _mapper.Map<PlayListOutputDto>(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _playlistRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(PlayList));

            await _playlistRepository.Delete(entity);

            return true;
        }
    }
}