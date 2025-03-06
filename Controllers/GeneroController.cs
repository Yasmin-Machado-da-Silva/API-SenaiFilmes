using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using API_Filmes_SENAI.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository; }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List < Genero > lista = _generoRepository.Listar();
                return StatusCode(200, lista );}

            catch (Exception error)
            {
                return BadRequest(error.Message);}

        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Genero novoGenero)
        {
            try {	        
		_generoRepository.Cadastrar(novoGenero);
                return Created();
                }
	
	catch (Exception error)
	{
                return BadRequest(error.Message);}

        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id){

            try
            {
                Genero generoBuscado = _generoRepository.BuscarPorId(id);
                return Ok(generoBuscado);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
}
        
[HttpDelete ("{id}")]
            public IActionResult Delete(Guid id)
            {
                   try
                {
                    _generoRepository.Deletar(id);
                        return NoContent();

                }
                catch (Exception)
                {

                    throw;
                }

        }

        [HttpPut ("id")]
        public IActionResult Put(Guid id, Genero genero)
        {
            try
            {
                _generoRepository.Atualizar(id, genero);
                return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}







