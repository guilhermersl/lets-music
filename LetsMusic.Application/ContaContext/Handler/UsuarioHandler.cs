using MediatR;
using LetsMusic.Application.ContaContext.Handler.Command;
using LetsMusic.Application.ContaContext.Handler.Query;
using LetsMusic.Application.ContaContext.Service;

namespace LetsMusic.Application.ContaContext.Handler
{
    public class UsuarioHandler : IRequestHandler<CreateUsuarioCommand, CreateUsuarioCommandResponse>,
                                  IRequestHandler<GetAllUsuarioQuery, GetAllUsuarioQueryResponse>,
                                  IRequestHandler<GetByIdUsuarioQuery, GetByIdUsuarioQueryResponse>,
                                  IRequestHandler<UpdateUsuarioCommand, UpdateUsuarioCommandResponse>,
                                  IRequestHandler<DeleteUsuarioCommand, bool>,
                                  IRequestHandler<AutenticateUsuarioQuery, bool>
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<CreateUsuarioCommandResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await _usuarioService.Create(request.Usuario);
            return new CreateUsuarioCommandResponse(result);
        }

        public async Task<GetAllUsuarioQueryResponse> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await _usuarioService.GetAll();
            return new GetAllUsuarioQueryResponse(result);
        }

        public async Task<GetByIdUsuarioQueryResponse> Handle(GetByIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await _usuarioService.GetById(request.Id);
            return new GetByIdUsuarioQueryResponse(result);
        }

        public async Task<UpdateUsuarioCommandResponse> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await _usuarioService.Update(request.Id, request.Usuario);
            return new UpdateUsuarioCommandResponse(result);
        }

        public async Task<bool> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            return await _usuarioService.Delete(request.Id);
        }

        public async Task<bool> Handle(AutenticateUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioService.Autentique(request.Email, request.Senha);
        }

    }
}
