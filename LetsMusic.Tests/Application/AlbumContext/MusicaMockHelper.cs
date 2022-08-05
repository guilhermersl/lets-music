using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Tests.Application.MusicaContext
{
    public class MusicaMockHelper
    {
        public static List<MusicaOutputDto> MockListMusicaOutputDto()
        {
            return new List<MusicaOutputDto>
                   {
                        MockMusicaOutputDto(),
                        MockMusicaOutputDto(),
                        MockMusicaOutputDto()
                   };
        }

        public static MusicaOutputDto MockMusicaOutputDto()
        {
            var id = Guid.NewGuid();
            return new MusicaOutputDto(id, $"nome musica {id}", "03:30", MockEstiloMusicalOutputDto());
        }

        public static EstiloMusicalOutputDto MockEstiloMusicalOutputDto()
        {
            var id = Guid.NewGuid();
            return new EstiloMusicalOutputDto(id, $"nome estilo musical {id}");
        }

        public static MusicaInputDto MockMusicInputDto()
            => new MusicaInputDto("nome musica 1", 200, MockEstiloMusicalInputDto());

        public static EstiloMusicalInputDto MockEstiloMusicalInputDto()
            => new EstiloMusicalInputDto("nome estilo musical 1");
    }
}
