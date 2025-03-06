using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListarController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IGeneroRepository _generoRepository;

        public ListarController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        // Método para listar os gêneros de filmes
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lista = _generoRepository.Listar();
                return Ok(lista); // StatusCode 200 já é o padrão do Ok()
            }
            catch (Exception error)
            {
                return BadRequest($"Erro ao listar gêneros: {error.Message}");
            }
        }
    }
}
