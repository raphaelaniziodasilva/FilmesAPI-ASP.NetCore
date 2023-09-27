using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos {
    public class CreateCinemaDto {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }

        // adicionando o id de relacionamento do endereco
        public int EnderecoId { get; set; }

        // em ReadCinemaDto liste as informaçoes do endereco que faz relacionamento

    }
}
