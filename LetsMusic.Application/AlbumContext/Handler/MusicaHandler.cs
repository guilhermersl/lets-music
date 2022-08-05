using MediatR;
using LetsMusic.Application.AlbumContext.Handler.Command;
using LetsMusic.Application.AlbumContext.Handler.Query;
using LetsMusic.Application.AlbumContext.Service;

namespace LetsMusic.Application.MusicaContext.Handler
{
    public class MusicaHandler : IRequestHandler<CreateMusicaCommand, CreateMusicaCommandResponse>,
                                 IRequestHandler<GetAllMusicaQuery, GetAllMusicaQueryResponse>,
                                 IRequestHandler<GetByIdMusicaQuery, GetByIdMusicaQueryResponse>,
                                 IRequestHandler<UpdateMusicaCommand, UpdateMusicaCommandResponse>,
                                 IRequestHandler<DeleteMusicaCommand, bool>
    {
        private readonly IMusicaService _musicaService;

        public MusicaHandler(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        public async Task<CreateMusicaCommandResponse> Handle(CreateMusicaCommand request, CancellationToken cancellationToken)
        {
            var result = await _musicaService.Create(request.Musica);
            return new CreateMusicaCommandResponse(result);
        }

        public async Task<GetAllMusicaQueryResponse> Handle(GetAllMusicaQuery request, CancellationToken cancellationToken)
        {
            var result = await _musicaService.GetAll();
            return new GetAllMusicaQueryResponse(result);
        }

        public async Task<GetByIdMusicaQueryResponse> Handle(GetByIdMusicaQuery request, CancellationToken cancellationToken)
        {
            var result = await _musicaService.GetById(request.Id);
            return new GetByIdMusicaQueryResponse(result);
        }

        public async Task<UpdateMusicaCommandResponse> Handle(UpdateMusicaCommand request, CancellationToken cancellationToken)
        {
            var result = await _musicaService.Update(request.Id, request.Musica);
            return new UpdateMusicaCommandResponse(result);
        }

        public async Task<bool> Handle(DeleteMusicaCommand request, CancellationToken cancellationToken)
        {
            return await _musicaService.Delete(request.Id);
        }
    }
}
