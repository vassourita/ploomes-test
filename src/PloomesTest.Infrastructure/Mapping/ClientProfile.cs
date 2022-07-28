using AutoMapper;
using PloomesTest.Core.Dtos;
using PloomesTest.Core.Entities;

namespace PloomesTest.Infrastructure.Mapping
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<UpdateClientDto, Client>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}