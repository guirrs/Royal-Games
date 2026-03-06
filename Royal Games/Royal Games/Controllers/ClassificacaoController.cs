using Microsoft.AspNetCore.Mvc;
using Royal_Games.Application.Services;
using Royal_Games.DTOs.ClassificacaoDto;
using Royal_Games.Exceptions;

[Route("api/[controller]")]
[ApiController]
public class ClassificacaoController : ControllerBase
{
    private readonly ClassificacaoService _service;

    public ClassificacaoController(ClassificacaoService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<LerClassificacaoDto>> Listar()
    {
        return Ok(_service.Listar());
    }

    [HttpGet("{id}")]
    public ActionResult<LerClassificacaoDto> ObterPorId(int id)
    {
        try
        {
            return Ok(_service.ObterPorId(id));
        }
        catch (DomainException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult<LerClassificacaoDto> Adicionar(CriarClassificacaoDto dto)
    {
        try
        {
            return Ok(_service.Adicionar(dto));
        }
        catch (DomainException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<LerClassificacaoDto> Atualizar(int id, CriarClassificacaoDto dto)
    {
        try
        {
            return Ok(_service.Atualizar(dto, id));
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
