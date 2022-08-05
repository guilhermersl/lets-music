using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Service
{
    public interface IMusicaService
    {
        Task<MusicaOutputDto> Create(MusicaInputDto dto);
        Task<List<MusicaOutputDto>> GetAll();
        Task<MusicaOutputDto> GetById(Guid id);
        Task<MusicaOutputDto> Update(Guid id, MusicaInputDto dto);
        Task<bool> Delete(Guid id);

    }
}