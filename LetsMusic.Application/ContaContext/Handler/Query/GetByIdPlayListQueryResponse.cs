using LetsMusic.Application.ContaContext.Dto;

namespace LetsMusic.Application.ContaContext.Handler.Query
{
    public class GetByIdPlayListQueryResponse
    {
        public PlayListOutputDto PlayList { get; set; }

        public GetByIdPlayListQueryResponse(PlayListOutputDto playlist)
        {
            PlayList = playlist;
        }
    }
}
