namespace LetsMusic.Domain.ContaContext.ValueObjects
{
    public class Email
    {
        public string Valor { get; set; }

        protected Email() { /* for EF */ }

        public Email(string email)
        {
            Valor = email ?? throw new ArgumentNullException(nameof(email));
        }

        public override string ToString()
        {
            return Valor;
        }
    }
}
