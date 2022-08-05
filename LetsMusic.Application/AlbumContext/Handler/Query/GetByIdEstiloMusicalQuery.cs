using MediatR;

namespace LetsMusic.Application.AlbumContext.Handler.Query
{
    public class GetByIdEstiloMusicalQuery : IRequest<GetByIdEstiloMusicalQueryResponse>
    {
        public Guid Id { get; set; }

        public GetByIdEstiloMusicalQuery(Guid id)
        {
            Id = id;
        }
    }
}
