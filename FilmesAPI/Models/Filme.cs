using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

// primeiro vamos criar o nosso modelo: entidade do banco de dados mysql
public class Filme {
    // adicionando validaçoes do Data Annotations

    [Key] // Id vai ser a chave primaria
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O título do filme é obrigatório")]
    [MaxLength(30, ErrorMessage = "O tamanho do título nao pode exceder 30 caracteres")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho do gênero nao pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O campo de duração é obrigatório")]
    [Range(80, 180, ErrorMessage = "A duraçao do filme deve ter entre 80 e 180 minutos")]
    public int Duracao { get; set; }
}

/* vamos fazer a conexao com o banco de dados mysql
 * crie uma pasta chamada Data e dentro uma classe FilmeContext 
 * com a conexao do db feita vamos rodar as migrations:
 *      criando tabela
 *      Add-Migration CriandoTabelaDeFilme
 *      criando banco de dados
 *      Update-Database


 precisamos criar os DTOs: (Data Transfer Object), ele que vai ficar responsavel por instanciar
 o objetos que vai os trafegar dados em diferentes camadas

 na pasta Data crie uma pasta chamada Dtos e depois a classe chamada CreateFilmeDto.cs
*/