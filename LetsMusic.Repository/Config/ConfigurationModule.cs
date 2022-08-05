using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LetsMusic.Data.Contexto;
using LetsMusic.Data.Database;
using LetsMusic.Data.Repository;
using LetsMusic.Domain.AlbumContext.Repository;
using LetsMusic.Domain.ContaContext.Repository;

namespace LetsMusic.Data.Config
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LetsMusicContext>(c => c.UseSqlServer(connectionString));

            services.AddScoped(typeof(Repository<>));
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IMusicaRepository, MusicaRepository>();
            services.AddScoped<IEstiloMusicalRepository, EstiloMusicalRepository>();
            services.AddScoped<IArtistaRepository, ArtistaRepository>();
            services.AddScoped<IPlayListRepository, PlayListRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
