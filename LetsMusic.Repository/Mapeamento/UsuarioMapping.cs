using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LetsMusic.Domain.ContaContext;

namespace LetsMusic.Data.Mapeamento
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(usuario => usuario.Id);

            builder.Property(usuario => usuario.Id).ValueGeneratedOnAdd();
            builder.Property(usuario => usuario.Nome).HasMaxLength(200);
            builder.Property(usuario => usuario.LinkFoto).HasMaxLength(500);
            builder.OwnsOne(usuario => usuario.Email, usuarioEmail =>
            {
                usuarioEmail.Property(email => email.Valor).HasColumnName("Email").IsRequired().HasMaxLength(500);
            });
            builder.OwnsOne(usuario => usuario.Senha, usuarioSenha =>
            {
                usuarioSenha.Property(senha => senha.Valor).HasColumnName("Senha").IsRequired().HasMaxLength(500);
            });
            builder.HasMany(usuario => usuario.PlayLists).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(usuario => usuario.PlayListsQueSegue).WithMany(playlist => playlist.Seguidores);
        }
    }
}
