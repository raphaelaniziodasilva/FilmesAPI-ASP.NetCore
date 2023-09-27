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

    [HttpPost]
    public IActionResult AdicionaSessao(CreatSessaoDto sessaoDto) {
        Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarSessoesPorId), new { Id = sessao.Id }, sessao);
    }

    [HttpGet]
    public IEnumerable<ReadSessaoDto> ListarSessoes() {
        return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult ListarSessoesPorId(int id) {
        Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
        if (sessao != null) {
            ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return Ok(sessaoDto);
        }
        return NotFound();
    }

}
