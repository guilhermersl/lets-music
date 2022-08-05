using Microsoft.EntityFrameworkCore;

namespace LetsMusic.Data.Contexto
{
    public class LetsMusicContext : DbContext
    {
        public LetsMusicContext(DbContextOptions<LetsMusicContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LetsMusicContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}