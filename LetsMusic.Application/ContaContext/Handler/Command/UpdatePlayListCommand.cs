using MediatR;
using LetsMusic.Application.ContaContext.Dto;

namespace LetsMusic.Application.ContaContext.Handler.Command
{
    public class UpdatePlayListCommand : IRequest<UpdatePlayListCommandResponse>
    {
        public Guid Id { get; set; }
        public PlayListInputDto PlayList { get; set; }

        public UpdatePlayListCommand(Guid id, PlayListInputDto playlist)
        {
            Id = id;
            PlayList = playlist;
        }
    }
}
