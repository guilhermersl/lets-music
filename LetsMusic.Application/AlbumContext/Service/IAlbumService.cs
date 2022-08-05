using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Service
{
    public interface IAlbumService
    {
        Task<AlbumOutputDto> Create(AlbumInputDto dto);
        Task<List<AlbumOutputDto>> GetAll();
        Task<AlbumOutputDto> GetById(Guid id);
        Task<AlbumOutputDto> Update(Guid id, AlbumInputDto dto);
        Task<bool> Delete(Guid id);

    }
}