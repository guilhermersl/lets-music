using MediatR;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class DeleteAlbumCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteAlbumCommand(Guid id)
        {
            Id = id;
        }
    }
}
