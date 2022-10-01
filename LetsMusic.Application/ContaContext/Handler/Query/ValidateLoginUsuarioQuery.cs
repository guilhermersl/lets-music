using MediatR;

namespace LetsMusic.Application.ContaContext.Handler.Query
{
    public class AutenticateUsuarioQuery : IRequest<bool>
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public AutenticateUsuarioQuery(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
    }
}
