using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Royal_Games.Application.Services;
using Royal_Games.DTOs.JogoDto;
using Royal_Games.DTOs.UsuarioDTO;
using Royal_Games.Exceptions;

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

        [HttpGet]
        public ActionResult <List<LerJogoDto>> Listar()
        {
            List<LerJogoDto> jogo = _service.Listar();
            return Ok(jogo);
        }

        [HttpGet("{id}")]
        public ActionResult <LerJogoDto> ObterPorId(int id)
        {
            LerJogoDto jogo = _service.ObterPorId(id);

            try
            {
                return Ok(jogo);
            }
            catch(DomainException ex)
            {
                throw new DomainException(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<LerJogoDto> Adicionar([FromForm] CriarJogoDto jogoDto)
        {
            try
            {

            }
        }
    }
}
