using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase {
    private FilmeContext _context;
    private IMapper _mapper;

    public SessaoController(FilmeContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    // Documentaçao com swagger 
    /// <summary>
    /// Adicionar a sessao ao banco de dados
    /// </summary>
    /// <param name="sessaoDto">Campos necessários para a criaçao da sessao</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Sessao cadastrada com sucesso</response>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public IActionResult AdicionaSessao(CreatSessaoDto sessaoDto) {
        Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarSessoesPorId), new { Id = sessao.Id }, sessao);
    }

    // Documentaçao com swagger 
    /// <summary>
    /// Listar todas as sessoes existentes no banco de dados
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Lista ok</response>

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public IEnumerable<ReadSessaoDto> ListarSessoes() {
        return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
    }

    // Documentaçao com swagger 
    /// <summary>
    /// Listar uma sessao existente do banco de dados
    /// </summary>
    /// <param name="id">Id da sessao</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a sessao seja listado com sucesso</response>

    [HttpGet("{id}", Name = "GetSessaoById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public IActionResult ListarSessoesPorId(int id) {
        Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
        if (sessao != null) {
            ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return Ok(sessaoDto);
        }
        return NotFound();
    }

}
