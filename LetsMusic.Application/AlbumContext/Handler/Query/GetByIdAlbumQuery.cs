using MediatR;

namespace LetsMusic.Application.AlbumContext.Handler.Query
{
    public class GetByIdAlbumQuery : IRequest<GetByIdAlbumQueryResponse>
    {
        public Guid Id { get; set; }

        public GetByIdAlbumQuery(Guid id)
        {
            Id = id;
        }
    }
}
