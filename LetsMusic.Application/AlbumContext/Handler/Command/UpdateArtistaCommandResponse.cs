using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class UpdateArtistaCommandResponse
    {
        public ArtistaOutputDto Artista { get; set; }

        public UpdateArtistaCommandResponse(ArtistaOutputDto artista)
        {
            Artista = artista;
        }
    }
}
