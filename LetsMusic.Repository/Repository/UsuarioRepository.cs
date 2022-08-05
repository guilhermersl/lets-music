using LetsMusic.Data.Contexto;
using LetsMusic.Data.Database;
using LetsMusic.Domain.ContaContext;
using LetsMusic.Domain.ContaContext.Repository;

namespace LetsMusic.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(LetsMusicContext context) : base(context) { }
    }
}
