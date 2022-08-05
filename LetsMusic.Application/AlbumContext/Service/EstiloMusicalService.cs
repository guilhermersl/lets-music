using AutoMapper;
using LetsMusic.Application.AlbumContext.Dto;
using LetsMusic.CrossCutting.Exceptions;
using LetsMusic.Domain.AlbumContext;
using LetsMusic.Domain.AlbumContext.Repository;

namespace LetsMusic.Application.AlbumContext.Service
{
    public class EstiloMusicalService : IEstiloMusicalService
    {
        private readonly IEstiloMusicalRepository _estiloMusicalRepository;
        private readonly IMapper _mapper;

        public EstiloMusicalService(IEstiloMusicalRepository estiloMusicalRepository, IMapper mapper)
        {
            _estiloMusicalRepository = estiloMusicalRepository;
            _mapper = mapper;
        }

        public async Task<EstiloMusicalOutputDto> Create(EstiloMusicalInputDto dto)
        {
            var estiloMusical = _mapper.Map<EstiloMusical>(dto);

            await _estiloMusicalRepository.Save(estiloMusical);

            return _mapper.Map<EstiloMusicalOutputDto>(estiloMusical);
        }

        public async Task<List<EstiloMusicalOutputDto>> GetAll()
        {
            var result = await _estiloMusicalRepository.GetAll();

            return _mapper.Map<List<EstiloMusicalOutputDto>>(result);
        }

        public async Task<EstiloMusicalOutputDto> GetById(Guid id)
        {
            var entity = await _estiloMusicalRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(EstiloMusical));

            return _mapper.Map<EstiloMusicalOutputDto>(entity);
        }

        public async Task<EstiloMusicalOutputDto> Update(Guid id, EstiloMusicalInputDto dto)
        {
            var entity = await _estiloMusicalRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(EstiloMusical));

            entity = _mapper.Map(dto, entity);
            await _estiloMusicalRepository.Update(entity);

            return _mapper.Map<EstiloMusicalOutputDto>(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _estiloMusicalRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(EstiloMusical));

            await _estiloMusicalRepository.Delete(entity);

            return true;
        }
    }
}