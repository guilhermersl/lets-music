using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class UpdateAlbumCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public UpdateAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
