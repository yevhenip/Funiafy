using AutoMapper;
using Identity.Data;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MapperProfiles
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<RegisterDTO, User>();
        }
    }
}