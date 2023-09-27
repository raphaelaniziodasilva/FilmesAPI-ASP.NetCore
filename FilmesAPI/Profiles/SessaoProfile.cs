using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles; 
public class SessaoProfile : Profile {

    public SessaoProfile() {
        CreateMap<CreatSessaoDto, Sessao>();
        CreateMap<Sessao, ReadSessaoDto>();
    }
}
