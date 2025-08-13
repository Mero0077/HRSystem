using AutoMapper;
using HRSystem.Features.FeatureScope.RemoveFeatureScope.DTOs;
using HRSystem.Features.FeatureScope.RemoveFeatureScope.VMs;

namespace HRSystem.Features.FeatureScope.RemoveFeatureScope.MappingProfile
{
    public class RemoveFeatureScopeProfile:Profile
    {
        public RemoveFeatureScopeProfile()
        {
            CreateMap<RemoveFeatureScopeRequestVM,RemoveFeatureScopeRequestDTO>();
            CreateMap<RemoveFeatureScopeRequestDTO, RemoveFeatureScopeResponseDTO>();
            CreateMap<RemoveFeatureScopeResponseDTO, removeFeatureScopeResponseVM>();
        }
    }
}
