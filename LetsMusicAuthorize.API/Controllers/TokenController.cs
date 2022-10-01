using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using LetsMusic.Application.ContaContext.Handler.Query;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LetsMusicAuthorize.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public TokenController(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Token([FromForm] string email, [FromForm] string senha)
        {
            var autenticado = await _mediator.Send(new AutenticateUsuarioQuery(email, senha));
            if (autenticado == false)
                return Unauthorized();

            var jwtSecret = _configuration["JwtSecret"];
            var audience = _configuration["Audience"];
            var issuer = _configuration["Issuer"];
            return Ok($"Bearer Token: {GerarToken(jwtSecret, audience, issuer, email)}");
        }

        private static string GerarToken(string jwtSecret, string audience, string issuer, string email)
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(jwtSecret));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("role", "User")
            };

            JwtSecurityToken token = new(issuer,
               audience,
               claims,
               expires: DateTime.Now.AddMinutes(15),
               signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}