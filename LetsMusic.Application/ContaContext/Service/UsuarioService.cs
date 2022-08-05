using AutoMapper;
using LetsMusic.Application.ContaContext.Dto;
using LetsMusic.CrossCutting.Exceptions;
using LetsMusic.Domain.ContaContext;
using LetsMusic.Domain.ContaContext.Repository;

namespace LetsMusic.Application.ContaContext.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioOutputDto> Create(UsuarioInputDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);

            usuario.Validate();

            await _usuarioRepository.Save(usuario);

            return _mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<List<UsuarioOutputDto>> GetAll()
        {
            var result = await _usuarioRepository.GetAll();

            return _mapper.Map<List<UsuarioOutputDto>>(result);
        }

        public async Task<UsuarioOutputDto> GetById(Guid id)
        {
            var entity = await _usuarioRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Usuario));

            return _mapper.Map<UsuarioOutputDto>(entity);
        }

        public async Task<UsuarioOutputDto> Update(Guid id, UsuarioInputDto dto)
        {
            var entity = await _usuarioRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Usuario));

            entity = _mapper.Map(dto, entity);

            entity.Validate();

            await _usuarioRepository.Update(entity);

            return _mapper.Map<UsuarioOutputDto>(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _usuarioRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Usuario));

            await _usuarioRepository.Delete(entity);

            return true;
        }
    }
}