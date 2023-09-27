using Newtonsoft.Json;

namespace FilmesAPI.Data.Dtos; 
public class ReadFilmeDto {
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;

    // usando ICollection<> para listar as informaçoes das ReadSessaoDto:sessoes
    // que faz relacionamento 1:n entre Sessao e Filme
    //[JsonIgnore]
    //public ICollection<ReadSessaoDto> Sessoes { get; set; }

    // em ReadCinemaDto use ICollection<> e liste as informaçoes das ReadSessaoDto:sessoes 



}
