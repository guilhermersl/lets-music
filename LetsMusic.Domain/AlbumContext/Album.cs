using LetsMusic.CrossCutting.BaseEntity;

namespace LetsMusic.Domain.AlbumContext
{
    public class Album : Entity<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string LinkFoto { get; set; }
        public int Ano { get; set; }
        public IList<Musica> Musicas { get; set; }

        protected Album() { /* for EF */ }

        public Album(string nome, Musica musica)
        {
            Nome = nome;
            if (musica == null)
            {
                throw new ArgumentNullException("Para criar um album, o album deve ter no minimo uma musica");
            }
            Musicas = new List<Musica> { musica };
        }

        public Album(string nome, IList<Musica> musicas)
        {
            Nome = nome;
            if (musicas.Any() == false)
            {
                throw new ArgumentNullException("Para criar um album, o album deve ter no minimo uma musica");
            }
            Musicas = musicas;
        }

        public int QuatidadeDeMusicas() => Musicas.Count;
    }
}