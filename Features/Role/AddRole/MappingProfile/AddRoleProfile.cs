using AutoMapper;
using HRSystem.Features.Role.AddRole.DTOs;

namespace HRSystem.Features.Role.AddRole.MappingProfile
{
    public class AddRoleProfile:Profile
    {
        public AddRoleProfile()
        {
            CreateMap<AddRoleRequestVM, AddRoleDTO>();
            CreateMap<AddRoleDTO, HRSystem.Models.Role>();
            CreateMap<HRSystem.Models.Role, AddRoleResponseVM>();
        }
    }
}
