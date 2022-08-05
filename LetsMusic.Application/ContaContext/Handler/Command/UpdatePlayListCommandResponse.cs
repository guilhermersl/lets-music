using LetsMusic.Application.ContaContext.Dto;

namespace LetsMusic.Application.ContaContext.Handler.Command
{
    public class UpdatePlayListCommandResponse
    {
        public PlayListOutputDto PlayList { get; set; }

        public UpdatePlayListCommandResponse(PlayListOutputDto playlist)
        {
            PlayList = playlist;
        }
    }
}
