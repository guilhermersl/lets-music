namespace LetsMusic.Domain.ContaContext.ValueObjects
{
    public class Senha
    {
        public string Valor { get; set; }

        protected Senha() { /* for EF */ }

        public Senha(string email)
        {
            Valor = email ?? throw new ArgumentNullException(nameof(email));
        }

    }
}
