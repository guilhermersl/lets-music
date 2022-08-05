using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Query
{
    public class GetAllAlbumQueryResponse
    {
        public IList<AlbumOutputDto> Albums { get; set; }

        public GetAllAlbumQueryResponse(IList<AlbumOutputDto> albums)
        {
            Albums = albums;
        }
    }
}
