using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;
/* vamos fazer a conexao com o banco de dados mysql, precisamos instalar os pacotes:
 * Microsoft.EntityFrameworkCore 
 * Microsoft.EntityFrameworkCore.Tools 
 * Pomelo.EntityFrameworkCore.MySql
*/

// a classe FilmeContext vai herdar de DbContext
public class FilmeContext : DbContext {
    // o contrutor vai receber as opçoes de acesso ao db: DbContextOptions
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        // passagem das opçoes para o construtor da classe que esta sendo herdada DbContext
        : base(opts){

    }

    // vamos criar a propriedade de acesso aos filmes
    public DbSet<Filme> Filmes { get; set; }
}

// agora vamos fazer a conexao com o db va para o arquivo appsettings.json