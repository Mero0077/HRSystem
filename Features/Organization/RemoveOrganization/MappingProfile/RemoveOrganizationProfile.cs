using AutoMapper;
using HRSystem.Features.Organization.RemoveOrganization.DTOs;

namespace HRSystem.Features.Organization.RemoveOrganization.MappingProfile
{
    public class RemoveOrganizationProfile:Profile
    {
        public RemoveOrganizationProfile()
        {
            CreateMap<RemoveOrganizationRequestVM,RemoveOrganizationDTO>();
            CreateMap<HRSystem.Models.Organization,RemoveOrganizationResponseVM>();
        }
    }
}
