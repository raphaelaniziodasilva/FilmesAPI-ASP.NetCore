using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos {
    public class CreateFilmeDto {
        [Required(ErrorMessage = "O título do filme é obrigatório")]
        [StringLength(30, ErrorMessage = "O tamanho do título nao pode exceder 30 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O gênero do filme é obrigatório")]
        [StringLength(50, ErrorMessage = "O tamanho do gênero nao pode exceder 50 caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo de duração é obrigatório")]
        [Range(80, 180, ErrorMessage = "A duraçao do filme deve ter entre 80 e 180 minutos")]
        public int Duracao { get; set; }
    }
}

// vamos criar o controller do Filme na pasta Controllers e crie a classe FilmeController.cs