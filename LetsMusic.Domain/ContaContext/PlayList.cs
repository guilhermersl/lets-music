using LetsMusic.CrossCutting.BaseEntity;
using LetsMusic.Domain.AlbumContext;

namespace LetsMusic.Domain.ContaContext
{
    public class PlayList : Entity<Guid>
    {
        public string Nome { get; set; }
        public IList<Musica> Musicas { get; set; }
        public IList<Usuario> Seguidores { get; set; }

        public PlayList()
        {
            Musicas = new List<Musica>();
        }

        public PlayList(string nome, IList<Musica> musicas)
        {
            Nome = nome;
            Musicas = musicas;
        }

    }
}