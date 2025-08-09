using AutoMapper;
using HRSystem.Features.Role.RemoveRole.DTOs;

namespace HRSystem.Features.Role.RemoveRole.MappingProfile
{
    public class RemoveRoleProfile:Profile
    {
        public RemoveRoleProfile()
        {
            CreateMap<RemoveRoleRequestVM, RemoveRoleDTO>();
            CreateMap<RemoveRoleDTO, HRSystem.Models.Role>();
            CreateMap<RemoveRoleDTO,RemoveRoleResponseVM >();
        }
    }
}
