using MediatR;
using LetsMusic.Application.AlbumContext.Handler.Command;
using LetsMusic.Application.AlbumContext.Handler.Query;
using LetsMusic.Application.AlbumContext.Service;

namespace LetsMusic.Application.ArtistaContext.Handler
{
    public class ArtistaHandler : IRequestHandler<CreateArtistaCommand, CreateArtistaCommandResponse>,
                                  IRequestHandler<GetAllArtistaQuery, GetAllArtistaQueryResponse>,
                                  IRequestHandler<GetByIdArtistaQuery, GetByIdArtistaQueryResponse>,
                                  IRequestHandler<UpdateArtistaCommand, UpdateArtistaCommandResponse>,
                                  IRequestHandler<DeleteArtistaCommand, bool>
    {
        private readonly IArtistaService _artistaService;

        public ArtistaHandler(IArtistaService artistaService)
        {
            _artistaService = artistaService;
        }

        public async Task<CreateArtistaCommandResponse> Handle(CreateArtistaCommand request, CancellationToken cancellationToken)
        {
            var result = await _artistaService.Create(request.Artista);
            return new CreateArtistaCommandResponse(result);
        }

        public async Task<GetAllArtistaQueryResponse> Handle(GetAllArtistaQuery request, CancellationToken cancellationToken)
        {
            var result = await _artistaService.GetAll();
            return new GetAllArtistaQueryResponse(result);
        }

        public async Task<GetByIdArtistaQueryResponse> Handle(GetByIdArtistaQuery request, CancellationToken cancellationToken)
        {
            var result = await _artistaService.GetById(request.Id);
            return new GetByIdArtistaQueryResponse(result);
        }

        public async Task<UpdateArtistaCommandResponse> Handle(UpdateArtistaCommand request, CancellationToken cancellationToken)
        {
            var result = await _artistaService.Update(request.Id, request.Artista);
            return new UpdateArtistaCommandResponse(result);
        }

        public async Task<bool> Handle(DeleteArtistaCommand request, CancellationToken cancellationToken)
        {
            return await _artistaService.Delete(request.Id);
        }

    }
}
