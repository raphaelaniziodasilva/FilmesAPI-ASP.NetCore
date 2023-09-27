using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles; 
public class EnderecoProfile : Profile {

    public EnderecoProfile() {
        // para o metodo adicionar
        CreateMap<CreateEnderecoDto, Endereco>();
        // para o metodo listar
        CreateMap<Endereco, ReadEnderecoDto>();
        // para o metodo atualizar
        CreateMap<UpdateEnderecoDto, Endereco>();
    }
}
