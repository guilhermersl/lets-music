using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Query
{
    public class GetByIdEstiloMusicalQueryResponse
    {
        public EstiloMusicalOutputDto EstiloMusical { get; set; }

        public GetByIdEstiloMusicalQueryResponse(EstiloMusicalOutputDto estiloMusical)
        {
            EstiloMusical = estiloMusical;
        }
    }
}
