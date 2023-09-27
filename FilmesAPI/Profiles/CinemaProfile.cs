using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles {
    public class CinemaProfile : Profile {

        public CinemaProfile() {
            // para o metodo adicionar
            CreateMap<CreateCinemaDto, Cinema>();
            // para o metodo listar
            CreateMap<Cinema, ReadCinemaDto>();
            // para o metodo atualizar
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
