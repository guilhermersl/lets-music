using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class CreateArtistaCommandResponse
    {
        public ArtistaOutputDto Artista { get; set; }

        public CreateArtistaCommandResponse(ArtistaOutputDto artista)
        {
            Artista = artista;
        }
    }
}
