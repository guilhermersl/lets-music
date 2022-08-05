using LetsMusic.Application.AlbumContext.Dto;

namespace LetsMusic.Tests.Application.AlbumContext
{
    public class AlbumMockHelper
    {
        public static AlbumOutputDto MockAlbumOutputDto()
        {
            var id = Guid.NewGuid();
            return new AlbumOutputDto(id, $"nome {id}", $"desc {id}", "link foto", 2022, MockListMusicaOutputDto());
        }

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

        public static AlbumInputDto MockAlbumInputDto()
            => new AlbumInputDto("Nome album", "Descricao album", "link foto", 2022,
                new List<MusicaInputDto>
                {
                    MockMusicInputDto(),
                    MockMusicInputDto(),
                    MockMusicInputDto()
                });

        public static MusicaInputDto MockMusicInputDto()
            => new MusicaInputDto("nome musica 1", 200, MockEstiloMusicalInputDto());

        public static EstiloMusicalInputDto MockEstiloMusicalInputDto()
            => new EstiloMusicalInputDto("nome estilo musical 1");
    }
}
