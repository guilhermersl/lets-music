using LetsMusic.Application.AlbumContext.Dto;
using LetsMusic.Domain.AlbumContext;

namespace LetsMusic.Application.AlbumContext.Profile
{
    public class AlbumProfile : AutoMapper.Profile
    {
        public AlbumProfile()
        {
            CreateMap<EstiloMusical, EstiloMusicalOutputDto>();

            CreateMap<EstiloMusicalInputDto, EstiloMusical>();

            CreateMap<Musica, MusicaOutputDto>()
                .ForMember(dto => dto.Duracao, config => config.MapFrom(musica => musica.Duracao.ValorFormatado));

            CreateMap<MusicaInputDto, Musica>()
                .ForPath(musica => musica.Duracao.Valor, config => config.MapFrom(dto => dto.Duracao));

            CreateMap<Album, AlbumOutputDto>();

            CreateMap<AlbumInputDto, Album>();

            CreateMap<Artista, ArtistaOutputDto>();

            CreateMap<ArtistaInputDto, Artista>();
        }
    }
}
