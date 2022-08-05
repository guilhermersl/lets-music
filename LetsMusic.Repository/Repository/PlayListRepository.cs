using LetsMusic.Data.Contexto;
using LetsMusic.Data.Database;
using LetsMusic.Domain.ContaContext;
using LetsMusic.Domain.ContaContext.Repository;

namespace LetsMusic.Data.Repository
{
    public class PlayListRepository : Repository<PlayList>, IPlayListRepository
    {
        public PlayListRepository(LetsMusicContext context) : base(context) { }
    }
}
