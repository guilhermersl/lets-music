using LetsMusic.CrossCutting.Interfaces.Data;

namespace LetsMusic.Domain.AlbumContext.Repository
{
    public interface IMusicaRepository : IRepository<Musica>
    {
        Task<IEnumerable<Musica>> GetAllWithIncludes();
    }
}
