using AutoMapper;
using HRSystem.Features.RoleFeature.AssignFeatureToRole.DTOs;

namespace HRSystem.Features.RoleFeature.AssignFeatureToRole.Mapping_Profile
{
    public class RoleFeatureProfile : Profile
    {
        public RoleFeatureProfile() 
        {
            CreateMap<AssignFeatureToRoleRequestViewModel,AssignFeatureToRoleRequestDTO>();
            CreateMap<AssignFeatureToRoleRequestDTO,Models.RoleFeature>();
        }
    }
}
