using AutoMapper;
using HRSystem.Features.UserFeature.AssignFeatureToUser.DTO;

namespace HRSystem.Features.UserFeature.AssignFeatureToUser.MappingProfile
{
    public class AssignFeatureToUserProfile:Profile
    {
        public AssignFeatureToUserProfile()
        {
            CreateMap<AssignFeatureToUserRequestVM, AssignFeatureToUserRequestDTO>();
            CreateMap<AssignFeatureToUserRequestDTO, HRSystem.Models.UserFeature>();
            CreateMap<HRSystem.Models.UserFeature, AssignFeatureToUserResponseDTO>();
            CreateMap<AssignFeatureToUserResponseDTO, AssignFeatureToUserResponseVM>();
        }
    }
}
