using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Royal_Games.Application.Services;
using Royal_Games.DTOs.JogoDto;
using Royal_Games.DTOs.UsuarioDTO;
using Royal_Games.Exceptions;
using System.Security.Claims;

namespace Royal_Games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly JogoService _service;
        public JogoController(JogoService service)
        {
            _service = service;
        }

        private int ObterUsuarioLogado()
        {
            string? idTexto = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(idTexto))
            {
                throw new DomainException("Usuario não autentificado");
            }

            return int.Parse(idTexto);
        }

        [HttpGet]
        public ActionResult<List<LerJogoDto>> Listar()
        {
            List<LerJogoDto> jogo = _service.Listar();
            return Ok(jogo);
        }

        [HttpGet("{id}")]
        public ActionResult<LerJogoDto> ObterPorId(int id)
        {
            LerJogoDto jogo = _service.ObterPorId(id);

            try
            {
                return Ok(jogo);
            }
            catch (DomainException ex)
            {
                throw new DomainException(ex.Message);
            }
        }

        [HttpPost]
        [Consumes("Multipart/form-data")]
        [Authorize]
        public ActionResult<LerJogoDto> Adicionar([FromForm] CriarJogoDto jogoDto)
        {
            try
            {
                int userId = ObterUsuarioLogado();

                _service.Adicionar(jogoDto,userId);

                return Created();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Consumes("Multipart/form-data")]
        [Authorize]
        public ActionResult Atualizar(int id, [FromForm] AtualizarJogoDto jogoDto)
        {
            try
            {
                _service.Atualizar(jogoDto, id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}