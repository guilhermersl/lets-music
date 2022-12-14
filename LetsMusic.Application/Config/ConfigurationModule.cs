using MediatR;
using Microsoft.Extensions.DependencyInjection;
using LetsMusic.Application.AlbumContext.Service;
using LetsMusic.Application.ContaContext.Service;
using LetsMusic.Data;
using System.Net.Http;

namespace LetsMusic.Application.Config
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConfigurationModule).Assembly);
            services.AddMediatR(typeof(ConfigurationModule).Assembly);

            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistaService, ArtistaService>();
            services.AddScoped<IEstiloMusicalService, EstiloMusicalService>();
            services.AddScoped<IMusicaService, MusicaService>();
            services.AddScoped<IPlayListService, PlayListService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddHttpClient();
            services.AddScoped<IAzureBlobStorage, AzureBlobStorage>();

            return services;
        }
    }
}
