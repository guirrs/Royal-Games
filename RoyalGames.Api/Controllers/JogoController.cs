using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("imagem/{id}")]
    public ActionResult ObterImagem(int id)
    {
        try
        {
            var imagem = _service.ObterImagem(id);
            return File(imagem, "imagem/jpeg");
        }
        catch (DomainException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("plataforma/{plataforma}")]
    public ActionResult<List<LerJogoDto>> ObterPorPlataforma(string plataforma)
    {
        try
        {
            return Ok(_service.ObterPorPlataforma(plataforma));
        }
        catch (DomainException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("genero/{genero}")]
    public ActionResult<List<LerJogoDto>> ObterPorGenero(string genero)
    {
        try
        {
            return Ok(_service.ObterPorGenero(genero));
        }
        catch (DomainException ex)
        {
            return BadRequest(ex.Message);
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

            _service.Adicionar(jogoDto, userId);

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

    [HttpDelete("{id}")]
    [Authorize]
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