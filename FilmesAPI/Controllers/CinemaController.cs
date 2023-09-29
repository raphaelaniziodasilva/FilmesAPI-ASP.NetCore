using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase {
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    // Documentaçao com swagger 
    /// <summary>
    /// Adicionar cinema ao banco de dados
    /// </summary>
    /// <param name="cinemaDto">Campos necessários para a criaçao do cinema</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Cinema cadastrado com sucesso</response>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto) {

        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarCinemaId), new {Id = cinema.Id}, cinemaDto);
    }

    // Documentaçao com swagger 
    /// <summary>
    /// Listar todos os cinemas existentes no banco de dados
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Lista ok</response>

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public IEnumerable<ReadCinemaDto> ListarCinemas() {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
    }

    // Documentaçao com swagger 
    /// <summary>
    /// Listar um cinema existente do banco de dados
    /// </summary>
    /// <param name="id">Id do cinema</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso o filme seja listado com sucesso</response>

    [HttpGet("{id}", Name = "GetCinemaById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public IActionResult ListarCinemaId(int id) {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if(cinema != null) {
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }
        return NotFound();
    }

    // Documentaçao com swagger - o metodo Put precisa de todo os atributos do cinema para atualiza
    /// <summary>
    /// Atualizar um cinema do banco de dados
    /// </summary>
    /// <param name="id">Id do cinema</param>
    /// <param name="cinemaDto">Campos necessários para a atualizaçao do cinema</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o cinema seja atualizado com sucesso</response>

    [HttpPut("{id}", Name = "AtualizarCinemaById")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDto cinemaDto) {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema == null) {
            return NotFound();
        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    // Documentaçao com swagger
    /// <summary>
    /// Deletar um cinema especifico do banco de dados
    /// </summary>
    /// <param name="id">Id do cinema</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o filme seja deletado com sucesso</response>

    [HttpDelete("{id}", Name = "DeletarCinemaById")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public IActionResult DeletarCinema(int id) {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema == null) {
            return NotFound();
        }
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }

}
