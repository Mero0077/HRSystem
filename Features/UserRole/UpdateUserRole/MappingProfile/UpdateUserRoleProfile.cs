using AutoMapper;
using HRSystem.Features.UserRole.AssignRoleToUser;
using HRSystem.Features.UserRole.DeleteUserRole.DTOs;
using HRSystem.Features.UserRole.UpdateUserRole.DTOs;

namespace HRSystem.Features.UserRole.UpdateUserRole.MappingProfile
{
    public class UpdateUserRoleProfile:Profile
    {
        public UpdateUserRoleProfile()
        {
            CreateMap<UpdateUserRoleRequestVM,UpdateUserRoleDTO>();
            CreateMap<UpdateUserRoleDTO,HRSystem.Models.UserRole>();
            CreateMap<UpdateUserRoleDTO,DeleteUserRoleDTO>();
            CreateMap<HRSystem.Models.UserRole, UpdateUserRoleResponseVM>();
        }
    }
}
