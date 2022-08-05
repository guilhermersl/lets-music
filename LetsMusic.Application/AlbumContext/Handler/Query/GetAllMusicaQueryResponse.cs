using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Application.AlbumContext.Handler.Query
{
    public class GetAllMusicaQueryResponse
    {
        public IList<MusicaOutputDto> Musicas { get; set; }

        public GetAllMusicaQueryResponse(IList<MusicaOutputDto> musicas)
        {
            Musicas = musicas;
        }
    }
}
