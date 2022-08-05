using MediatR;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class DeleteMusicaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteMusicaCommand(Guid id)
        {
            Id = id;
        }
    }
}
