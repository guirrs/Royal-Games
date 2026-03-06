using Microsoft.AspNetCore.Mvc;
using Royal_Games.Application.Services;
using Royal_Games.DTOs.JogoDto;
using Royal_Games.Exceptions;
using System.Security.Claims;

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
            throw new DomainException("Usuário não autenticado");
        }

        return int.Parse(idTexto);
    }
    [HttpGet]
    public ActionResult<List<LerJogoDto>> Listar()
    {
        List<LerJogoDto> jogos = _service.Listar();
        return Ok(jogos);
    }

    [HttpGet("{id}")]
    public ActionResult<LerJogoDto> ObterPorId(int id)
    {
        try
        {
            LerJogoDto jogo = _service.ObterPorId(id);
            return Ok(jogo);
        }
        catch (DomainException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult<LerJogoDto> Adicionar([FromForm] CriarJogoDto jogoDto)
    {
        try
        {
            int userId = ObterUsuarioLogado();
            LerJogoDto jogoCriado = _service.Adicionar(jogoDto, userId);

            return CreatedAtAction(nameof(ObterPorId), new { id = jogoCriado.Nome }, jogoCriado);
        }
        catch (DomainException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
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

[HttpDelete("{id}")]
public ActionResult Deletar(int id)
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