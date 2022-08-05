using MediatR;
using LetsMusic.Application.ContaContext.Dto;

namespace LetsMusic.Application.ContaContext.Handler.Command
{
    public class CreatePlayListCommand : IRequest<CreatePlayListCommandResponse>
    {
        public PlayListInputDto PlayList { get; set; }

        public CreatePlayListCommand(PlayListInputDto playlist)
        {
            PlayList = playlist;
        }
    }
}
