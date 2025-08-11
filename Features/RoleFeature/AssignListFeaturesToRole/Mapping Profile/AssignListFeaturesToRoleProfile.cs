using AutoMapper;
using HRSystem.Features.RoleFeature.AssignListFeaturesToRoleCommandHandler.DTOs;

namespace HRSystem.Features.RoleFeature.AssignListFeaturesToRoleCommandHandler.Mapping_Profile
{
    public class AssignListFeaturesToRoleProfile : Profile
    {
        public AssignListFeaturesToRoleProfile() 
        {
            CreateMap<AssignListFeaturesToRoleRequestViewModel, AssignListFeaturesToRoleRequestDTO>();
        }
    }
}
