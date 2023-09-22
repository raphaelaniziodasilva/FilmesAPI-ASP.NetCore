using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.Extensions.Hosting;

namespace FilmesAPI.Profiles;
/* para converter as informaçoes e criar um filme do tipo CreateFilmeDto
 * precisamos utilizar o AutoMapper, vai fazer um mapeamento automatico de um Dto
 * instalar libs AutoMapper:
 * AutoMapper
 * AutoMapper.Extensions.Microsoft.DependencyInjection
 * 
 * para utilizar o AutoMapper precisamos adicionar no arquivo Program.cs
*/

public class FilmeProfile : Profile {
    // precisamos do construtor
    public FilmeProfile() {
        // definindo o mapeamento de CreateFilmeDto para Filme:model metodo post
        CreateMap<CreateFilmeDto, Filme>();

        // definindo o mapeamento de Filme:model para ReadFilmeDto metodo get
        CreateMap<Filme, ReadFilmeDto>();

        // definindo o mapeamento de UpdateFilmeDto para Filme:model metodo put
        CreateMap<UpdateFilmeDto, Filme>();

        // definindo o mapeamento de Filme:model para UpdateFilmeDto metodo patch
        CreateMap<Filme, UpdateFilmeDto>();
    }
}
