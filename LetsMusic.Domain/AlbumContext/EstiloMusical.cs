using LetsMusic.CrossCutting.BaseEntity;

namespace LetsMusic.Domain.AlbumContext
{
    public class EstiloMusical : Entity<Guid>
    {
        public string Nome { get; set; }
    }
}