using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Royal_Games.Application.Services;
using Royal_Games.DTO.PlataformaDTo;
using Royal_Games.DTOs.GeneroDto;
using Royal_Games.DTOs.PlataformaDto;
using Royal_Games.Exceptions;

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
            List<LerPlataformaDTO> plataforma = _service.Listar();

            return Ok(plataforma);
        }

        [HttpGet("{id}")]
        public ActionResult<LerGeneroDTO> ObterPorId(int id)
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
        public ActionResult<LerPlataformaDTO> Adicionar(CriarPlataformaDTO PlataformaDto)
        {
            try
            {
                 _service.Cadastrar(PlataformaDto);
                return NoContent();
            }
            catch (DomainException ex)
            {
                throw new DomainException(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Atualizar(int id, LerPlataformaDTO PlataformaDto)
        {
            try
            {
                 _service.Atualizar(id, PlataformaDto);
                return NoContent();
            }
            catch (DomainException ex)
            {
                throw new DomainException(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult<LerPlataformaDTO> Remover(int id)
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

    

