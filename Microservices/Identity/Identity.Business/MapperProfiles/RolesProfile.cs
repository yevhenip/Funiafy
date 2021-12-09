using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MapperProfiles
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            CreateMap<IdentityRole, RoleDTO>().ReverseMap();
        }
    }
}