using AutoMapper;
using LetsMusic.Application.AlbumContext.Dto;
using LetsMusic.CrossCutting.Exceptions;
using LetsMusic.Domain.AlbumContext;
using LetsMusic.Domain.AlbumContext.Repository;

namespace LetsMusic.Application.AlbumContext.Service
{
    public class MusicaService : IMusicaService
    {
        private readonly IMusicaRepository _musicaRepository;
        private readonly IMapper _mapper;

        public MusicaService(IMusicaRepository musicaRepository, IMapper mapper)
        {
            _musicaRepository = musicaRepository;
            _mapper = mapper;
        }

        public async Task<MusicaOutputDto> Create(MusicaInputDto dto)
        {
            var musica = _mapper.Map<Musica>(dto);

            await _musicaRepository.Save(musica);

            return _mapper.Map<MusicaOutputDto>(musica);
        }

        public async Task<List<MusicaOutputDto>> GetAll()
        {
            var result = await _musicaRepository.GetAllWithIncludes();

            return _mapper.Map<List<MusicaOutputDto>>(result);
        }

        public async Task<MusicaOutputDto> GetById(Guid id)
        {
            var entity = await _musicaRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Musica));

            return _mapper.Map<MusicaOutputDto>(entity);
        }

        public async Task<MusicaOutputDto> Update(Guid id, MusicaInputDto dto)
        {
            var entity = await _musicaRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Musica));

            entity = _mapper.Map(dto, entity);
            await _musicaRepository.Update(entity);

            return _mapper.Map<MusicaOutputDto>(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _musicaRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Musica));

            await _musicaRepository.Delete(entity);

            return true;
        }
    }
}