using LetsMusic.Application.ContaContext.Dto;

namespace LetsMusic.Application.ContaContext.Service
{
    public interface IPlayListService
    {
        Task<PlayListOutputDto> Create(PlayListInputDto dto);
        Task<List<PlayListOutputDto>> GetAll();
        Task<PlayListOutputDto> GetById(Guid id);
        Task<PlayListOutputDto> Update(Guid id, PlayListInputDto dto);
        Task<bool> Delete(Guid id);

    }
}