using AutoMapper;
using PloomesTest.Core.Dtos;
using PloomesTest.Core.Entities;

namespace PloomesTest.Infrastructure.Mapping
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientDto, Client>();
            CreateMap<UpdateClientDto, Client>();
        }
    }
}