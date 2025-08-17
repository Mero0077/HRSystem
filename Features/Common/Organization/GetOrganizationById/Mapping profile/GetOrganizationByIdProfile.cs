using AutoMapper;
using HRSystem.Features.Common.Organization.GetOrganizationById.DTOs;

namespace HRSystem.Features.Common.Organization.GetOrganizationById.Mapping_profile
{
    public class GetOrganizationByIdProfile : Profile
    {
        public GetOrganizationByIdProfile() 
        {
            CreateMap<Models.Organization, GetOrganizationByIdResponseDTO>()
                .ForMember(des=>des.CompanyIds,opt=>opt.MapFrom(src=>src.companies.Select(e=>e.Id).ToList()));
        }
    }
}
