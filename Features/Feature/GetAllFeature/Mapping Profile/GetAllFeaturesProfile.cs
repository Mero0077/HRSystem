using AutoMapper;
using HRSystem.Features.Feature.GetAllFeature.DTOs;

namespace HRSystem.Features.Feature.GetAllFeature.Mapping_Profile
{
    public class GetAllFeaturesProfile : Profile
    {
        public GetAllFeaturesProfile() 
        {
            CreateMap<Models.Feature, GetAllFeaturesResponseDTO>();
            CreateMap<GetAllFeaturesResponseDTO, GetAllFeaturesResponseViewModel>();
        }
    }
}
