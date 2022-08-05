using LetsMusic.CrossCutting.BaseEntity;
using LetsMusic.Domain.AlbumContext.ValueObjects;
using LetsMusic.Domain.ContaContext;

namespace LetsMusic.Domain.AlbumContext
{
    public class Musica : Entity<Guid>
    {
        public string Nome { get; set; }
        public EstiloMusical EstiloMusical { get; set; }
        public Duracao Duracao { get; set; }
        public IList<PlayList> PlayLists { get; set; }

        public Musica()
        {
            PlayLists = new List<PlayList>();
        }
    }
}