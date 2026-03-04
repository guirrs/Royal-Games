using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Royal_Games.Application.Services;
using Royal_Games.DTOs.GeneroDto;
using Royal_Games.Exceptions;

namespace Royal_Games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly GeneroService _service;

    public  GeneroController(GeneroService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerGeneroDTO>> Listar()
        {
            List<LerGeneroDTO> genero = _service.Listar();

            return Ok(genero);
        }

        [HttpGet("{id}")]
        public ActionResult<LerGeneroDTO> ObterPorId(int id)
        {
            try
            {
                LerGeneroDTO genero = _service.ObterPorID(id);
                return Ok(genero);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<LerGeneroDTO> Adicionar(CriarGeneroDTO GeneroDto)
        {
            try
            {
                _service.Cadastrar(GeneroDto);
                return NoContent();
            }
            catch (DomainException ex)
            {
                throw new DomainException(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Atualizar(int id, LerGeneroDTO GeneroDTO)
        {
            try
            {
               _service.Atualizar(id, GeneroDTO);
                return NoContent();
            }
            catch (DomainException ex)
            {
                throw new DomainException(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult<LerGeneroDTO> Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                throw new DomainException(ex.Message);
            }
        }
    }
}