using LetsMusic.Data.Contexto;
using LetsMusic.Data.Database;
using LetsMusic.Domain.AlbumContext;
using LetsMusic.Domain.AlbumContext.Repository;

namespace LetsMusic.Data.Repository
{
    public class ArtistaRepository : Repository<Artista>, IArtistaRepository
    {
        public ArtistaRepository(LetsMusicContext context) : base(context) { }
    }
}
