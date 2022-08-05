using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class UpdateMusicaCommandResponse
    {
        public MusicaOutputDto Musica { get; set; }

        public UpdateMusicaCommandResponse(MusicaOutputDto musica)
        {
            Musica = musica;
        }
    }
}
