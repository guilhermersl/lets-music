namespace LetsMusic.Domain.AlbumContext.ValueObjects
{
    public class Duracao
    {
        public int Valor { get; set; }
        public string ValorFormatado => FormatarValor();

        protected Duracao() { /* for EF */ }

        public Duracao(int duracaoEmSegundos)
        {
            Valor = duracaoEmSegundos;
        }

        public override string ToString()
        {
            return FormatarValor();
        }

        private string FormatarValor()
        {
            var duracao = TimeSpan.FromSeconds(Valor);

            if (duracao.TotalHours >= 1)
                return $"{duracao.Hours}:{duracao.Minutes}:{duracao.Seconds}";

            return $"{duracao.Minutes} min {duracao.Seconds} seg";
        }
    }
}
