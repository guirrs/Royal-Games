using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Royal_Games.Application.Services;
using Royal_Games.DTOs.ClassificacaoDto;
using Royal_Games.DTOs.LerUsuarioDTO;
using Royal_Games.Exceptions;

namespace Royal_Games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificacaoController : ControllerBase
    {
        private readonly ClassificacaoService _service;

        ClassificacaoController(ClassificacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerClassificacaoDto>> Listar()
        {
            List<LerClassificacaoDto> classificacao = _service.Listar();

            return Ok(classificacao);
        }

        [HttpGet("{id}")]
        public ActionResult<LerClassificacaoDto> ObterPorId(int id)
        {
            try
            {
                LerClassificacaoDto classificacao = _service.ObterPorId(id);
                return Ok(classificacao);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<LerClassificacaoDto> Adicionar(CriarGeneroDto classificacaoDto)
        {
            try
            {
                LerClassificacaoDto classificacao = _service.Adicionar(classificacaoDto);
                return Ok(classificacao);
            }
            catch (DomainException ex)
            {
                throw new DomainException(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<LerClassificacaoDto> Atualizar(CriarGeneroDto classificacaoDto, int id)
        {
            try
            {
                LerClassificacaoDto classificacao = _service.Atualizar(classificacaoDto, id);
                return Ok(classificacao);
            }
            catch (DomainException ex)
            {
                throw new DomainException(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult<LerClassificacaoDto> Remover(int id)
        {
            try
            {
                LerClassificacaoDto classificacao = _service.Remover(id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                throw new DomainException(ex.Message);
            }
        }
    }
}
