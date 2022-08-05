using LetsMusic.Data.Contexto;
using LetsMusic.Data.Database;
using LetsMusic.Domain.AlbumContext;
using LetsMusic.Domain.AlbumContext.Repository;

namespace LetsMusic.Data.Repository
{
    public class EstiloMusicalRepository : Repository<EstiloMusical>, IEstiloMusicalRepository
    {
        public EstiloMusicalRepository(LetsMusicContext context) : base(context) { }
    }
}
