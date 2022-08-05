using MediatR;

namespace LetsMusic.Application.AlbumContext.Handler.Query
{
    public class GetByIdMusicaQuery : IRequest<GetByIdMusicaQueryResponse>
    {
        public Guid Id { get; set; }

        public GetByIdMusicaQuery(Guid id)
        {
            Id = id;
        }
    }
}
