using MediatR;
using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class CreateEstiloMusicalCommand : IRequest<CreateEstiloMusicalCommandResponse>
    {
        public EstiloMusicalInputDto EstiloMusical { get; set; }

        public CreateEstiloMusicalCommand(EstiloMusicalInputDto estiloMusical)
        {
            EstiloMusical = estiloMusical;
        }
    }
}
