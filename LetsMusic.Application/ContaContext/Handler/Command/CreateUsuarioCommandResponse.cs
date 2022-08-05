using LetsMusic.Application.ContaContext.Dto;

namespace LetsMusic.Application.ContaContext.Handler.Command
{
    public class CreateUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public CreateUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
