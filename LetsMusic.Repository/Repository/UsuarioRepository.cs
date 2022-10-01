using LetsMusic.Data.Contexto;
using LetsMusic.Data.Database;
using LetsMusic.Domain.ContaContext;
using LetsMusic.Domain.ContaContext.Repository;
using Microsoft.EntityFrameworkCore;

namespace LetsMusic.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(LetsMusicContext context) : base(context) { }

        public async Task<bool> Autentique(string email, string senha)
        {
            var usuarios = await Query.Where(usuario => usuario.Email.Valor == email && usuario.Senha.Valor == senha)
                                                .ToListAsync();
            return usuarios.Any();
        }
    }
}
