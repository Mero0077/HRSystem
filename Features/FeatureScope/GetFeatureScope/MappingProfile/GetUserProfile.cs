using AutoMapper;
using HRSystem.Features.Common.User.GetUser;
using HRSystem.Features.FeatureScope.GetFeatureScope.DTOs;
using HRSystem.Features.FeatureScope.GetFeatureScope.VMs;

namespace HRSystem.Features.FeatureScope.GetFeatureScope.MappingProfile
{
    public class GetUserProfile:Profile
    {
        public GetUserProfile()
        {
            CreateMap<GetFeatureScopeRequestVM,GetFeatureScopeRequestDTO>();
            CreateMap<GetFeatureScopeRequestDTO, GetFeatureScopeResponseDTO>();
            CreateMap<GetFeatureScopeResponseDTO, GetFeatureScopeResponseVM>();
        }
    }
}
