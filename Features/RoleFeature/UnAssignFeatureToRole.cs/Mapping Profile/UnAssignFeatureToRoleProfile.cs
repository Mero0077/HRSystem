using AutoMapper;
using HRSystem.Features.RoleFeature.UnAssignFeatureToRole.cs.DTOs;

namespace HRSystem.Features.RoleFeature.UnAssignFeatureToRole.cs.Mapping_Profile
{
    public class UnAssignFeatureToRoleProfile : Profile
    {
        public UnAssignFeatureToRoleProfile()
        {
            CreateMap<UnAssignFeatureToRoleRequestDTO,Models.RoleFeature>();
            CreateMap<UnAssignFeatureToRoleRequestViewModel, Models.RoleFeature>();
        }
    }
}
