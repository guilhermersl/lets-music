using Microsoft.EntityFrameworkCore;
using LetsMusic.Data.Contexto;
using LetsMusic.Data.Database;
using LetsMusic.Domain.AlbumContext;
using LetsMusic.Domain.AlbumContext.Repository;

namespace LetsMusic.Data.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(LetsMusicContext context) : base(context) { }

        public async Task<IEnumerable<Album>> GetAllWithIncludes()
        {
            return await Query.Include(album => album.Musicas)
                              .ThenInclude(musica => musica.EstiloMusical)
                              .ToListAsync();
        }
    }
}
