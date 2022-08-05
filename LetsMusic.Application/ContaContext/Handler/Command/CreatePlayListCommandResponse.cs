using LetsMusic.Application.ContaContext.Dto;

namespace LetsMusic.Application.ContaContext.Handler.Command
{
    public class CreatePlayListCommandResponse
    {
        public PlayListOutputDto PlayList { get; set; }

        public CreatePlayListCommandResponse(PlayListOutputDto playlist)
        {
            PlayList = playlist;
        }
    }
}
