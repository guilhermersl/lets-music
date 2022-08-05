using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LetsMusic.Domain.AlbumContext;

namespace LetsMusic.Data.Mapeamento
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");
            builder.HasKey(album => album.Id);

            builder.Property(album => album.Id).ValueGeneratedOnAdd();
            builder.Property(album => album.Nome).HasMaxLength(200);
            builder.Property(album => album.Descricao).HasMaxLength(500);
            builder.Property(album => album.LinkFoto).HasMaxLength(500);
            builder.Property(album => album.Ano).IsRequired();

            builder.HasMany(album => album.Musicas).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
