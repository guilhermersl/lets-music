using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Query
{
    public class GetAllEstiloMusicalQueryResponse
    {
        public IList<EstiloMusicalOutputDto> EstilosMusicais { get; set; }

        public GetAllEstiloMusicalQueryResponse(IList<EstiloMusicalOutputDto> estilosMusicais)
        {
            EstilosMusicais = estilosMusicais;
        }
    }
}
