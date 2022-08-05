using LetsMusic.Application.ContaContext.Dto;

namespace LetsMusic.Application.ContaContext.Handler.Command
{
    public class UpdateUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public UpdateUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
