using MediatR;
using LetsMusic.Application.AlbumContext.Handler.Command;
using LetsMusic.Application.AlbumContext.Handler.Query;
using LetsMusic.Application.AlbumContext.Service;

namespace LetsMusic.Application.EstiloMusicalContext.Handler
{
    public class EstiloMusicalHandler : IRequestHandler<CreateEstiloMusicalCommand, CreateEstiloMusicalCommandResponse>,
                                        IRequestHandler<GetAllEstiloMusicalQuery, GetAllEstiloMusicalQueryResponse>,
                                        IRequestHandler<GetByIdEstiloMusicalQuery, GetByIdEstiloMusicalQueryResponse>,
                                        IRequestHandler<UpdateEstiloMusicalCommand, UpdateEstiloMusicalCommandResponse>,
                                        IRequestHandler<DeleteEstiloMusicalCommand, bool>
    {
        private readonly IEstiloMusicalService _estiloMusicalService;

        public EstiloMusicalHandler(IEstiloMusicalService estiloMusicalService)
        {
            _estiloMusicalService = estiloMusicalService;
        }

        public async Task<CreateEstiloMusicalCommandResponse> Handle(CreateEstiloMusicalCommand request, CancellationToken cancellationToken)
        {
            var result = await _estiloMusicalService.Create(request.EstiloMusical);
            return new CreateEstiloMusicalCommandResponse(result);
        }

        public async Task<GetAllEstiloMusicalQueryResponse> Handle(GetAllEstiloMusicalQuery request, CancellationToken cancellationToken)
        {
            var result = await _estiloMusicalService.GetAll();
            return new GetAllEstiloMusicalQueryResponse(result);
        }

        public async Task<GetByIdEstiloMusicalQueryResponse> Handle(GetByIdEstiloMusicalQuery request, CancellationToken cancellationToken)
        {
            var result = await _estiloMusicalService.GetById(request.Id);
            return new GetByIdEstiloMusicalQueryResponse(result);
        }

        public async Task<UpdateEstiloMusicalCommandResponse> Handle(UpdateEstiloMusicalCommand request, CancellationToken cancellationToken)
        {
            var result = await _estiloMusicalService.Update(request.Id, request.EstiloMusical);
            return new UpdateEstiloMusicalCommandResponse(result);
        }

        public async Task<bool> Handle(DeleteEstiloMusicalCommand request, CancellationToken cancellationToken)
        {
            return await _estiloMusicalService.Delete(request.Id);
        }
    }
}
