using MediatR;
using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Command
{
    public class UpdateMusicaCommand : IRequest<UpdateMusicaCommandResponse>
    {
        public Guid Id { get; set; }
        public MusicaInputDto Musica { get; set; }

        public UpdateMusicaCommand(Guid id, MusicaInputDto musica)
        {
            Id = id;
            Musica = musica;
        }
    }
}
