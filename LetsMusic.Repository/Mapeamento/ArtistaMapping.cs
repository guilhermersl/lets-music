using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LetsMusic.Domain.AlbumContext;

namespace LetsMusic.Data.Mapeamento
{
    public class ArtistaMapping : IEntityTypeConfiguration<Artista>
    {
        public void Configure(EntityTypeBuilder<Artista> builder)
        {
            builder.ToTable("Artista");
            builder.HasKey(artista => artista.Id);

            builder.Property(artista => artista.Id).ValueGeneratedOnAdd();
            builder.Property(artista => artista.Nome).IsRequired().HasMaxLength(200);
            builder.Property(artista => artista.Descricao).HasMaxLength(500);
            builder.Property(artista => artista.LinkFoto).HasMaxLength(500);
            builder.Property(artista => artista.Tipo);

            builder.HasMany(artista => artista.Albuns).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
