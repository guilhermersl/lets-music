using MediatR;
using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class CreateMusicaCommand : IRequest<CreateMusicaCommandResponse>
    {
        public MusicaInputDto Musica { get; set; }

        public CreateMusicaCommand(MusicaInputDto musica)
        {
            Musica = musica;
        }
    }
}
