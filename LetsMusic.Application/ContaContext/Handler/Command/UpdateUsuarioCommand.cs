using MediatR;
using LetsMusic.Application.ContaContext.Dto;

namespace LetsMusic.Application.ContaContext.Handler.Command
{
    public class UpdateUsuarioCommand : IRequest<UpdateUsuarioCommandResponse>
    {
        public Guid Id { get; set; }
        public UsuarioInputDto Usuario { get; set; }

        public UpdateUsuarioCommand(Guid id, UsuarioInputDto usuario)
        {
            Id = id;
            Usuario = usuario;
        }
    }
}
