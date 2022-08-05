using MediatR;

namespace LetsMusic.Application.ContaContext.Handler.Command
{
    public class DeletePlayListCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeletePlayListCommand(Guid id)
        {
            Id = id;
        }
    }
}
