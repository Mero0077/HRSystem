using AutoMapper;
using HRSystem.Features.UserRole.DeleteUserRole.DTOs;

namespace HRSystem.Features.UserRole.DeleteUserRole.MappingProfile
{
    public class DeleteUserRoleProfile:Profile
    {
        public DeleteUserRoleProfile()
        {
            CreateMap<DeleteUserRoleRequestVM,DeleteUserRoleDTO>();
            CreateMap<DeleteUserRoleDTO, HRSystem.Models.UserRole>();
            CreateMap<HRSystem.Models.UserRole, DeleteUserRoleResponseVM>();
        }
    }
}
