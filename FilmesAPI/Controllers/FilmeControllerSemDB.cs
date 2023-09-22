/*
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmeControllerSemDB : ControllerBase {
    // quando nao temos banco de dados precisamos adicionar e salvar o filme em uma lista
    // para poder adicionar o filme precisamos criar a lista de filmes
    private static List<Filme> filmes = new List<Filme>();

    // o id vai comecar com 1 e com cada filme adicionado na lista vai incremenrando
    private static int id = 1;

    // metodo para adicionar filmes
    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] Filme filme) {
        // adicionando id e adicionando o filme na lista de filmes
        filme.Id = id++;
        filmes.Add(filme); 

         // CreatedAtAction recebe um metodo e executa para retornar o objeto que foi criado, 
         // vamos usar o metodo ListarFilmeId que retornara o filme cirado
        return CreatedAtAction(nameof(ListarFilmeId),
            // parametro: id que o metodo ListarFilmeId precisa para retornar filme criado
            new { id = filme.Id },
            // objeto que foi criado
            filme);
    }

    // metodo para listar todos os filmes adicionados

    [HttpGet]
    // IEnumerable também vai atuar como o List
    public IEnumerable<Filme> ListarFilmes(
        // vamos fazer a paginaçao utilizando skip e take, caso o usuario nao digite a paginacao 
        [FromQuery] int skip = 0, // posiçao 0
        [FromQuery] int take = 20) { // ate a posicao 20

        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    // IActionResult e uma interface de resultado de uma açao que foi ececutada
    public IActionResult ListarFilmeId(int id) {
        var Filme = filmes.FirstOrDefault(filme => filme.Id == id);

        if (Filme == null) {
            return NotFound();
        }
        return Ok(Filme);

        // NotFound() e Ok() sao metodos da classe ControllerBase
    }

}
*/