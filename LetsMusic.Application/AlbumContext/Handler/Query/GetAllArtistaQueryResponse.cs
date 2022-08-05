using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Query
{
    public class GetAllArtistaQueryResponse
    {
        public IList<ArtistaOutputDto> Artistas { get; set; }

        public GetAllArtistaQueryResponse(IList<ArtistaOutputDto> artistas)
        {
            Artistas = artistas;
        }
    }
}
