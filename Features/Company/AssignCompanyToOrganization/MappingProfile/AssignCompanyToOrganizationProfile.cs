using AutoMapper;
using HRSystem.Features.Company.AssignCompanyToOrganization.DTOs;
using HRSystem.Features.Company.AssignCompanyToOrganization.VMs;

namespace HRSystem.Features.Company.AssignCompanyToOrganization.MappingProfile
{
    public class AssignCompanyToOrganizationProfile:Profile
    {
        public AssignCompanyToOrganizationProfile()
        {
            CreateMap<AssignCompanyToOrganizationRequestVM, AssignCompanyToOrganizationRequestDTO>();
            CreateMap<AssignCompanyToOrganizationRequestDTO, AssignCompanyToOrganizationResponseDTO>();
            CreateMap<AssignCompanyToOrganizationResponseDTO, AssignCompanyToOrganizationResponseVM>();
        }
    }
}
