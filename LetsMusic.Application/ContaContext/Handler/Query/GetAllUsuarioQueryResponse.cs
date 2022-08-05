using LetsMusic.Application.ContaContext.Dto;

namespace LetsMusic.Application.ContaContext.Handler.Query
{
    public class GetAllUsuarioQueryResponse
    {
        public IList<UsuarioOutputDto> Usuarios { get; set; }

        public GetAllUsuarioQueryResponse(IList<UsuarioOutputDto> usuarios)
        {
            Usuarios = usuarios;
        }
    }
}
