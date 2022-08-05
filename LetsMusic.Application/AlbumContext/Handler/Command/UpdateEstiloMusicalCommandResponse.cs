using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class UpdateEstiloMusicalCommandResponse
    {
        public EstiloMusicalOutputDto EstiloMusical { get; set; }

        public UpdateEstiloMusicalCommandResponse(EstiloMusicalOutputDto estiloMusical)
        {
            EstiloMusical = estiloMusical;
        }
    }
}
