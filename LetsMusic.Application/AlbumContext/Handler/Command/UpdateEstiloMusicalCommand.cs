using MediatR;
using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class UpdateEstiloMusicalCommand : IRequest<UpdateEstiloMusicalCommandResponse>
    {
        public Guid Id { get; set; }
        public EstiloMusicalInputDto EstiloMusical { get; set; }

        public UpdateEstiloMusicalCommand(Guid id, EstiloMusicalInputDto estiloMusical)
        {
            Id = id;
            EstiloMusical = estiloMusical;
        }
    }
}
