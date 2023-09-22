using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;
/* aqui vai ser o nosso controller do filme, vamos usar os metodos http entre outros...
 * para que esse controller esteja apto para receber as requisiçoes e lidar com as requisiçoes
 * do usuario precisamos adicionar as anotaçoes:
*/
[ApiController]
[Route("[controller]")]

// a classe FilmeController precisar herdar:extender de ControllerBase
public class FilmeController : ControllerBase {
    /* com o banco de dados criado e configurado, vamos adicionar e salvar o filme no db
     * chamando o db */
    private FilmeContext _context;
    // chamando o AutoMapper para converter o Dto para o filme
    private IMapper _mapper;

    // criando contrutor da classe FilmeController para ter acesso ao db e AutoMapper
    public FilmeController(FilmeContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    /* metodo para adicionar filmes
     * IActionResult e uma interface de resultado de uma açao que foi ececutada 
     * FromBody vai enviar as informaçoes do filme atraves do corpo da requisiçao
    */
    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto) {
        /*  precisamos converter as informaçoes para criar um filme do tipo CreateFilmeDto
         *  o _context salva no db o filme do tipo Filme:model e nao do tipo CreateFilmeDto
         *  crie uma pasta chamada Profiles e a classe FilmeProfile.cs
        */

        /* utilizando o AutoMapper para criar um filme do tipo CreateFilmeDto 
         * e tirando a responsabilidade do models */
        Filme filme = _mapper.Map<Filme>(filmeDto);

        // usando o _context para ir ate a tabela filmes e adicionando o filme
        _context.Filmes.Add(filme);
        // salvando o filme dentro do db
        _context.SaveChanges();
        

        /* CreatedAtAction recebe um metodo e executa para retornar o objeto que foi criado, 
         * vamos usar o metodo ListarFilmeId que retornara o filme cirado */
        return CreatedAtAction(nameof(ListarFilmeId),
            // parametro: id que o metodo ListarFilmeId precisa para retornar filme criado
            new { id = filme.Id },
            // objeto que foi criado
            filme);
    }

    // metodo para listar todos os filmes adicionados
    [HttpGet]
    /* IEnumerable também vai atuar como o List
     * crie o Dto de leitura na pasta Data e dentro de Dtos crie a classe ReadFilmeDto.cs */
    public IEnumerable<ReadFilmeDto> ListarFilmes(
        // vamos fazer a paginaçao utilizando skip e take, caso o usuario nao digite a paginacao 
        [FromQuery] int skip = 0, // posiçao 0
        [FromQuery] int take = 20) { // ate a posicao 20

        /* converter as informaçoes para ler o filme do tipo ReadFilmeDto 
         * dentro da pasta Profiles na classe FilmeProfile.cs converta ReadFilmeDto
         * 
         * utilizando o AutoMapper para mapear a lista do tipo ReadFilmeDto, 
         * tirando a responsabilidade do models e
         * buscando todos os filmes que estao salvos no db
        */
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));

        /* o usuario digitou ate 30 
         * https://localhost:7214/filme?take=30 */
    }

    // metodo para listar o filme pelo id
    [HttpGet("{id}")]
    // IActionResult e uma interface de resultado de uma açao que foi ececutada
    public IActionResult ListarFilmeId(int id) {
        // buscando o filme pelo id que esta salvo no db
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) {
            return NotFound();
        }

        /* utilizando o AutoMapper para mapear a lista do tipo ReadFilmeDto e
         * tirando a responsabilidade do models */
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

        return Ok(filmeDto);

        // NotFound() e Ok() sao metodos da classe ControllerBase
    }

    // metodo para atualizar filme, o metodo Put precisa de todo o filme para atualiza
    [HttpPut("{id}")]
    // crie o Dto de atualizaçao na pasta Data e dentro de Dtos crie a classe UpdateFilmeDto.cs 
    public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto) {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) {
            return NotFound();
        }

        /* converter as informaçoes para atualizar o filme do tipo UpdateFilmeDto 
         * dentro da pasta Profiles na classe FilmeProfile.cs converta UpdateFilmeDto
         * 
         * utilizando o AutoMapper para atualizar filme do tipo UpdateFilmeDto e 
         * tirando a responsabilidade do models
        */
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    // metodo para atualizar filme, o metodo Patch precisa de um campo especifico para atualizar e nao o filme inteiro
    [HttpPatch("{id}")]
    public IActionResult AtualizarCampoFilme(int id, JsonPatchDocument<UpdateFilmeDto> patch) {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) {
            return NotFound();
        }
        /* vamos instalar uma lib para fazer o manuseio do json: 
         *          Microsoft.AspNetCore.Mvc.NewtonsoftJson 
         * precisamos adicionar no arquivo Program.cs em builder.Services.AddControllers(); 
         * 
         * converter o filme que pegamos no db para UpdateFilmeDto para poder aplicar as 
         * regras de validaçao e tirando a responsabilidade do models
        */
        var filmeAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        // se a mudança que estamos aplicando patch for aplicado ao filmeAtualizar e tiver o estado valido
        patch.ApplyTo(filmeAtualizar, ModelState);

        /* se for valido vamos fazer a mudança convertendo de volta para o filme 
         * se nao for valido descartamos no meio do caminho com erro de validaçao */
        if(!TryValidateModel(filmeAtualizar)) {
            return ValidationProblem(ModelState);
        }
        
        // dentro da pasta Profiles na classe FilmeProfile.cs e faça o inverso do put  

        // vamos mapear filmeAtualizar para filme
        _mapper.Map(filmeAtualizar, filme); 
        _context.SaveChanges();
        return NoContent();
    }

    // metodo para deletar filme
    [HttpDelete("{id}")]
    public IActionResult DeleteFilme(int id) {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) {
            return NotFound(); 
        }

        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}

// na pasta de Proprierties launchSettings.json e configure para usar o postman e sweager
