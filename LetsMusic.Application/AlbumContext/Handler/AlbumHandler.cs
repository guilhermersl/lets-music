using MediatR;
using LetsMusic.Application.AlbumContext.Handler.Command;
using LetsMusic.Application.AlbumContext.Handler.Query;
using LetsMusic.Application.AlbumContext.Service;
using LetsMusic.Application.ContaContext.Handler.Command;

namespace LetsMusic.Application.AlbumContext.Handler
{
    public class AlbumHandler : IRequestHandler<CreateAlbumCommand, CreateAlbumCommandResponse>,
                                IRequestHandler<GetAllAlbumQuery, GetAllAlbumQueryResponse>,
                                IRequestHandler<GetByIdAlbumQuery, GetByIdAlbumQueryResponse>,
                                IRequestHandler<UpdateAlbumCommand, UpdateAlbumCommandResponse>,
                                IRequestHandler<DeleteAlbumCommand, bool>
    {
        private readonly IAlbumService _albumService;

        public AlbumHandler(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public async Task<CreateAlbumCommandResponse> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await _albumService.Create(request.Album);
            return new CreateAlbumCommandResponse(result);
        }

        public async Task<GetAllAlbumQueryResponse> Handle(GetAllAlbumQuery request, CancellationToken cancellationToken)
        {
            var result = await _albumService.GetAll();
            return new GetAllAlbumQueryResponse(result);
        }

        public async Task<GetByIdAlbumQueryResponse> Handle(GetByIdAlbumQuery request, CancellationToken cancellationToken)
        {
            var result = await _albumService.GetById(request.Id);
            return new GetByIdAlbumQueryResponse(result);
        }

        public async Task<UpdateAlbumCommandResponse> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await _albumService.Update(request.Id, request.Album);
            return new UpdateAlbumCommandResponse(result);
        }

        public async Task<bool> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            return await _albumService.Delete(request.Id);
        }

    }
}
