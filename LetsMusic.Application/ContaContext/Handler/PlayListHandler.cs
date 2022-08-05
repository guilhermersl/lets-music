using MediatR;
using LetsMusic.Application.ContaContext.Handler.Command;
using LetsMusic.Application.ContaContext.Handler.Query;
using LetsMusic.Application.ContaContext.Service;

namespace LetsMusic.Application.ContaContext.Handler
{
    public class PlayListHandler : IRequestHandler<CreatePlayListCommand, CreatePlayListCommandResponse>,
                                   IRequestHandler<GetAllPlayListQuery, GetAllPlayListQueryResponse>,
                                   IRequestHandler<GetByIdPlayListQuery, GetByIdPlayListQueryResponse>,
                                   IRequestHandler<UpdatePlayListCommand, UpdatePlayListCommandResponse>,
                                   IRequestHandler<DeletePlayListCommand, bool>
    {
        private readonly IPlayListService _playListService;

        public PlayListHandler(IPlayListService playListService)
        {
            _playListService = playListService;
        }

        public async Task<CreatePlayListCommandResponse> Handle(CreatePlayListCommand request, CancellationToken cancellationToken)
        {
            var result = await _playListService.Create(request.PlayList);
            return new CreatePlayListCommandResponse(result);
        }

        public async Task<GetAllPlayListQueryResponse> Handle(GetAllPlayListQuery request, CancellationToken cancellationToken)
        {
            var result = await _playListService.GetAll();
            return new GetAllPlayListQueryResponse(result);
        }

        public async Task<GetByIdPlayListQueryResponse> Handle(GetByIdPlayListQuery request, CancellationToken cancellationToken)
        {
            var result = await _playListService.GetById(request.Id);
            return new GetByIdPlayListQueryResponse(result);
        }

        public async Task<UpdatePlayListCommandResponse> Handle(UpdatePlayListCommand request, CancellationToken cancellationToken)
        {
            var result = await _playListService.Update(request.Id, request.PlayList);
            return new UpdatePlayListCommandResponse(result);
        }

        public async Task<bool> Handle(DeletePlayListCommand request, CancellationToken cancellationToken)
        {
            return await _playListService.Delete(request.Id);
        }

    }
}
