using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api_filmes_senai.Domains;
using api_filmes_senai.DTO;
using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDTO.Email, loginDTO.Senha);
                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario n'ao encontrado, email ou senha invalidos!");
                }
                //caso o usuario seja encontrado, prossegue para a criacao do token
                //1 passo- definir as claims() que serao fornecidos no token
                //claim seria informacoes
                var claims = new[]
                {
                       new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                       new Claim (JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                        new Claim (JwtRegisteredClaimNames.Name, usuarioBuscado.Nome),
                new Claim ("Nome da Claim" ,"Valor da claim")
                   };
                //2* passo - Definir a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filme-chaver-autenticacao-webapi-dev"));

                //3* passo - Definir as credeciais do token(HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                //4* passo - Gerar o taken
                var token = new JwtSecurityToken
                    (
                        //EMISSOR DO TEKEN
                        issuer: "api_filmes_senai",
                        //DESTINATARIO DO TOKEN
                        audience: "api_filmes_senai",
                        //dados definidos nas claims
                        claims: claims,
                        //tempo de expiracao de taken
                        expires: DateTime.Now.AddMinutes(5),
                        //credenciais do token
                        signingCredentials: creds
                    );
                return Ok(

                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),

                    }
                    );
            }


            catch (Exception error)
            {
                return BadRequest(error.Message);

            }
        }
    }
}
