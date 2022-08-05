using LetsMusic.CrossCutting.BaseEntity;
using LetsMusic.Domain.AlbumContext.Enums;

namespace LetsMusic.Domain.AlbumContext
{
    public class Artista : Entity<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string LinkFoto { get; set; }
        public TipoArtista Tipo { get; set; }
        public IList<Album> Albuns { get; set; }

        protected Artista() { /* for EF */ }

        public Artista(string nome)
        {
            Nome = nome;
            Albuns = new List<Album>();
        }

        public Artista(string nome, Album album)
        {
            Nome = nome;
            Albuns = new List<Album> { album };
        }

        public IEnumerable<Musica> ListeMusicas() => Albuns.SelectMany(album => album.Musicas);
        public IEnumerable<EstiloMusical> ListeEstilosMusiccais() => ListeMusicas().Select(musica => musica.EstiloMusical).Distinct();
    }
}