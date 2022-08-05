using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Query
{
    public class GetByIdArtistaQueryResponse
    {
        public ArtistaOutputDto Artista { get; set; }

        public GetByIdArtistaQueryResponse(ArtistaOutputDto artista)
        {
            Artista = artista;
        }
    }
}
