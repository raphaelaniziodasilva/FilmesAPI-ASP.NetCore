using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models; 
public class Sessao {
    [Key]
    [Required] 
    public int Id { get; set; }


    // relacionamento 1:n entre Sessao e Filme
    public int? FilmeId { get; set; }
    public virtual Filme Filme { get; set; }
    // agora va para o model Filme terminar o relacionamento

    // relacionamento 1:n entre Sessao e Cinema
    public int? CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; }
    // agora va para o model Cinema terminar o relacionamento

    // adicione o FilmeId e CinemaId no dto CreatSessaoDto
}

/* vamos gerar as migrations das tabelas Cinema e Endereco ja com os relacionamento feito
 *      Add-Migration "Sessao e filme"
 *      Update-Database
*/
