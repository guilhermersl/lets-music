using LetsMusic.Application.ContaContext.Dto;
using LetsMusic.Domain.ContaContext;

namespace LetsMusic.Application.ContaContext.Profile
{
    public class ContaProfile : AutoMapper.Profile
    {
        public ContaProfile()
        {
            CreateMap<Usuario, UsuarioOutputDto>()
                .ForMember(dto => dto.Email, config => config.MapFrom(musica => musica.Email.Valor));

            CreateMap<UsuarioInputDto, Usuario>()
                .ForPath(musica => musica.Email.Valor, config => config.MapFrom(dto => dto.Email))
                .ForPath(musica => musica.Senha.Valor, config => config.MapFrom(dto => dto.Senha));

            CreateMap<PlayList, PlayListOutputDto>();

            CreateMap<PlayListInputDto, PlayList>();
        }
    }
}
