using Microsoft.AspNetCore.Mvc;
using Royal_Games.Application.Services;
using Royal_Games.DTO.GeneroDTo;
using Royal_Games.Exceptions;
using System.Collections.Generic;

namespace Royal_Games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly GeneroService _service;

        public GeneroController(GeneroService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerGeneroDTO>> Listar()
        {
            List<LerGeneroDTO> generos = _service.Listar();
            return Ok(generos);
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
        public ActionResult Adicionar(CriarGeneroDTO generoDto)
        {
            try
            {
                _service.Cadastrar(generoDto);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, LerGeneroDTO generoDTO)
        {
            try
            {
                _service.Atualizar(id, generoDTO);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}