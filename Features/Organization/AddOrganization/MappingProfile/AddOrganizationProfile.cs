using AutoMapper;
using HRSystem.Features.Organization.AddOrganization.DTOs;

namespace HRSystem.Features.Organization.AddOrganization.MappingProfile
{
    public class AddOrganizationProfile:Profile
    {
        public AddOrganizationProfile()
        {
            CreateMap<AddOrganizationRequestVM,AddOrganizationDTO>();
            CreateMap<HRSystem.Models.Organization,AddOrganizationReponseVM>();
        }
    }
}
