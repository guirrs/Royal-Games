using Microsoft.AspNetCore.Mvc;
using Royal_Games.Application.Services;
using Royal_Games.Domains;
using Royal_Games.DTO;
using Royal_Games.DTO.PlataformaDTo;
using Royal_Games.Exceptions;
using System.Collections.Generic;

namespace Royal_Games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlataformaController : ControllerBase
    {
        private readonly PlataformaService _service;

        public PlataformaController(PlataformaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerPlataformaDTO>> Listar()
        {
            List<LerPlataformaDTO> plataformas = _service.Listar();
            return Ok(plataformas);
        }

        [HttpGet("{id}")]
        public ActionResult<LerPlataformaDTO> ObterPorId(int id)
        {
            try
            {
                LerPlataformaDTO plataforma = _service.ObterPorID(id);
                return Ok(plataforma);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Adicionar(CriarPlataformaDTO plataformaDto)
        {
            try
            {
                _service.Cadastrar(plataformaDto); 
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, LerPlataformaDTO plataformaDto)
        {
            try
            {
                _service.Atualizar(id, plataformaDto);
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
