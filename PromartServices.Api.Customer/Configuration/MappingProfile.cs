using AutoMapper;
using PromartServices.Api.Customer.Dto;
using PromartServices.Api.Customer.Model;

namespace PromartServices.Api.Customer.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>()
                .ForMember(o => o.id, b => b.MapFrom(z => z.ClientId))
                .ForMember(o => o.nombres, b => b.MapFrom(z => z.FirstName))
                .ForMember(o => o.apellidos, b => b.MapFrom(z => z.LastName))
                .ForMember(o => o.fecha_nacimiento, b => b.MapFrom(z => z.Birthdate));
        }
    }
}
