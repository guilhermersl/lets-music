using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Query
{
    public class GetByIdMusicaQueryResponse
    {
        public MusicaOutputDto Musica { get; set; }

        public GetByIdMusicaQueryResponse(MusicaOutputDto musica)
        {
            Musica = musica;
        }
    }
}
