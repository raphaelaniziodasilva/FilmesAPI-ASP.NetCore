using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase {
    private FilmeContext _context;
    private IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    // Documentaçao com swagger 
    /// <summary>
    /// Adicionar endereço ao banco de dados
    /// </summary>
    /// <param name="enderecoDto">Campos necessários para a criaçao do endereço</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Endereço cadastrado com sucesso</response>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto) {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();

        return CreatedAtAction(nameof(ListarEnderecoId), new { Id = endereco.Id}, endereco);
    }

    // Documentaçao com swagger 
    /// <summary>
    /// Listar todos os endereços existentes no banco de dados
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Lista ok</response>

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public IEnumerable<ReadEnderecoDto> ListarEnderecos() {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos);
    }

    // Documentaçao com swagger 
    /// <summary>
    /// Listar um endereço existente do banco de dados
    /// </summary>
    /// <param name="id">Id do endereço</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso o endereço seja listado com sucesso</response>

    [HttpGet("{id}", Name = "GetEnderecoById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public IActionResult ListarEnderecoId(int id) {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if(endereco != null) {
            ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return Ok(enderecoDto);
        }
        return NotFound();
    }

    // Documentaçao com swagger - o metodo Put precisa de todo os atributos do cinema para atualiza
    /// <summary>
    /// Atualizar um endereço do banco de dados
    /// </summary>
    /// <param name="id">Id do endereço</param>
    /// <param name="enderecoDto">Campos necessários para a atualizaçao do endereço</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o endereço seja atualizado com sucesso</response>

    [HttpPut("{id}", Name = "AtualizarEnderecoById")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto) {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) {
            return NotFound();
        }
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    // Documentaçao com swagger
    /// <summary>
    /// Deletar um endereço especifico do banco de dados
    /// </summary>
    /// <param name="id">Id do endereço</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o endereço seja deletado com sucesso</response>

    [HttpDelete("{id}", Name = "DeletarEnderecoById")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public IActionResult DeletarEndereco(int id) {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) {
            return NotFound();
        }
        _context.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }
}
