using Newtonsoft.Json;

namespace FilmesAPI.Data.Dtos; 
public class ReadCinemaDto {
    public int Id { get; set; }
    public string Nome { get; set; }

    // listar as informaçoes do endereco que faz relacionamento 1:1 entre Cinema e Endereco
    public ReadEnderecoDto Endereco { get; set; }

    // usando ICollection<> para listar as informaçoes das ReadSessaoDto:sessoes
    // que faz relacionamento 1:n entre Sessao e Cinema
    //[JsonIgnore]
    //public ICollection<ReadSessaoDto> Sessoes { get; set; }

}
