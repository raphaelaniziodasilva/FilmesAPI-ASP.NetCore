namespace FilmesAPI.Data.Dtos; 
public class ReadSessaoDto {
    public int Id { get; set; }


    // listar as informaçoes do filme que faz relacionamento 1:n entre Sessao e Filme
    public ReadFilmeDto Filme { get; set; }

    // listar as informaçoes do cinema que faz relacionamento 1:n entre Sessao e Cinema
    public ReadCinemaDto Cinema { get; set; }

    // em ReadFilmeDto use ICollection<>liste as informaçoes do filme que faz relacionamento

}
