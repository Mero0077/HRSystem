using AutoMapper;
using HRSystem.Features.UserRole.AssignRoleToUser;
using HRSystem.Features.UserRole.AssignRoleToUser.DTOs;

namespace HRSystem.Features.UserRole.AssignRoleToUser.MappingProfile
{
    public class AssignRoleToUserProfile : Profile
    {
        public AssignRoleToUserProfile()
        {
            CreateMap<AssignRoleToUserRequestVM, AssignRoleToUserDTO>();
            CreateMap<AssignRoleToUserDTO, Models.UserRole>();
            CreateMap<Models.UserRole, AssignRoleToUserResponseVM>();
        }
    }
}
