using MediatR;
using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class CreateArtistaCommand : IRequest<CreateArtistaCommandResponse>
    {
        public ArtistaInputDto Artista { get; set; }

        public CreateArtistaCommand(ArtistaInputDto artista)
        {
            Artista = artista;
        }
    }
}
