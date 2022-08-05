using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LetsMusic.Domain.AlbumContext;

namespace LetsMusic.Data.Mapeamento
{
    public class MusicaMapping : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable("Musica");
            builder.HasKey(musica => musica.Id);

            builder.Property(musica => musica.Id).ValueGeneratedOnAdd();
            builder.Property(musica => musica.Nome).IsRequired().HasMaxLength(200);
            builder.HasOne(musica => musica.EstiloMusical);
            builder.HasMany(musica => musica.PlayLists).WithMany(playlist => playlist.Musicas);

            builder.OwnsOne(musica => musica.Duracao, musicaDuracao =>
            {
                musicaDuracao.Property(duracao => duracao.Valor).HasColumnName("DuracaoEmSegundos").IsRequired();
            });
        }
    }
}
