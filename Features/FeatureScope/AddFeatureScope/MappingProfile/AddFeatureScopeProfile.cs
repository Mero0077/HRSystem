using AutoMapper;
using HRSystem.Features.FeatureScope.AddFeatureScope.DTOs;
using HRSystem.Features.FeatureScope.AddFeatureScope.VMs;

namespace HRSystem.Features.FeatureScope.AddFeatureScope.MappingProfile
{
    public class AddFeatureScopeProfile:Profile
    {
        public AddFeatureScopeProfile()
        {
            CreateMap<AddFeatureScopeRequestVM, AddFeatureScopeRequestDTO>();
            CreateMap<AddFeatureScopeRequestDTO, HRSystem.Models.FeatureScope>();
            CreateMap<HRSystem.Models.FeatureScope, AddFeatureScopeResponseDTO>();
            CreateMap<AddFeatureScopeResponseDTO, AddFeatureScopeResponseVM>();
        }
    }
}
