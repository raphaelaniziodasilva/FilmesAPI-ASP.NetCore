using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models; 
public class Endereco {
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório.")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório.")]
    public int Numero {  get; set; }

    // terminando o relacionamento 1:1 entre Cinema e Endereco
    public virtual Cinema Cinema { get; set; }

}
