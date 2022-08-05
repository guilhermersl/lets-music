using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class CreateAlbumCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public CreateAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
