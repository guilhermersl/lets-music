using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Service
{
    public interface IEstiloMusicalService
    {
        Task<EstiloMusicalOutputDto> Create(EstiloMusicalInputDto dto);
        Task<List<EstiloMusicalOutputDto>> GetAll();
        Task<EstiloMusicalOutputDto> GetById(Guid id);
        Task<EstiloMusicalOutputDto> Update(Guid id, EstiloMusicalInputDto dto);
        Task<bool> Delete(Guid id);
    }
}