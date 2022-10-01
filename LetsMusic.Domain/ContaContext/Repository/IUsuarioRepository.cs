using LetsMusic.CrossCutting.Interfaces.Data;

namespace LetsMusic.Domain.ContaContext.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario> 
    {
        Task<bool> Autentique(string email, string senha);
    }
}
