using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class CreateEstiloMusicalCommandResponse
    {
        public EstiloMusicalOutputDto EstiloMusical { get; set; }

        public CreateEstiloMusicalCommandResponse(EstiloMusicalOutputDto estiloMusical)
        {
            EstiloMusical = estiloMusical;
        }
    }
}
