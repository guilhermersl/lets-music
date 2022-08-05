using MediatR;

namespace LetsMusic.Application.AlbumContext.Handler.Query
{
    public class GetAllAlbumQuery : IRequest<GetAllAlbumQueryResponse> { }
}
