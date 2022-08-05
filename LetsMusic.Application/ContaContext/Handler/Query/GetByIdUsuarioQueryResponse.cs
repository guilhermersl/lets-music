using LetsMusic.Application.ContaContext.Dto;

namespace LetsMusic.Application.ContaContext.Handler.Query
{
    public class GetByIdUsuarioQueryResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public GetByIdUsuarioQueryResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
