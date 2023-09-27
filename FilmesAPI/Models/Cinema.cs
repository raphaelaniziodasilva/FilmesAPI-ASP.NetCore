using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models; 
public class Cinema {
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório.")]
    public string Nome { get; set; }


    /* relacionamento 1:1 entre Cinema e Endereco
     * precisamos instalar um pacote que vai trazer as informaçoes do relacionamento
     *                  Microsoft.EntityFrameworkCore.Proxies
     * 
     * va para o arquivo Program.cs, precisamos configurar e informar o carregamento das 
     * informaçoes do Endereco
    */
    [Required]
    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }
    // agora va para o model Endereco terminar o relacionamento

    // adicione o EnderecoId no dto CreateCinemaDto

    // terminando o relacionamento 1:n entre Sessao e Cinema
    public virtual ICollection<Sessao> Sessoes { get; set; }
}

/* vamos gerar as migrations das tabelas Cinema e Endereco ja com os relacionamento feito
 *      Add-Migration "Cinema e Endereco"
 *      Update-Database
*/