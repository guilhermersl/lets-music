using LetsMusic.CrossCutting.Interfaces.Data;

namespace LetsMusic.Domain.AlbumContext.Repository
{
    public interface IAlbumRepository : IRepository<Album> {
        Task<IEnumerable<Album>> GetAllWithIncludes();
    }
}
