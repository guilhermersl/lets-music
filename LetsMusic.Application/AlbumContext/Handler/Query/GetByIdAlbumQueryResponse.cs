using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Query
{
    public class GetByIdAlbumQueryResponse
    {
        public AlbumOutputDto Album { get; set; }

        public GetByIdAlbumQueryResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
