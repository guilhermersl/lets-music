using Microsoft.EntityFrameworkCore;
using LetsMusic.Data.Contexto;
using LetsMusic.Data.Database;
using LetsMusic.Domain.AlbumContext;
using LetsMusic.Domain.AlbumContext.Repository;

namespace LetsMusic.Data.Repository
{
    public class MusicaRepository : Repository<Musica>, IMusicaRepository
    {
        public MusicaRepository(LetsMusicContext context) : base(context) { }

        public async Task<IEnumerable<Musica>> GetAllWithIncludes()
        {
            return await Query.Include(musica => musica.EstiloMusical)
                              .ToListAsync();
        }
    }
}
