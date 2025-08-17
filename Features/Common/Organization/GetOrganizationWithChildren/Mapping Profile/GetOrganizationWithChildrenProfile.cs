using AutoMapper;
using HRSystem.Features.Common.Organization.GetOrganizationWithChildren.DTOs;

namespace HRSystem.Features.Common.Organization.GetOrganizationWithChildren.Mapping_Profile
{
    public class GetOrganizationWithChildrenProfile : Profile
    {
        public GetOrganizationWithChildrenProfile() 
        {
            CreateMap<Models.Organization, GetOrganizationWithChildrenResponseDTO>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.Companies, opt => opt.MapFrom(src => src.companies));

            CreateMap<Models.Company, CompanyResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.BranchIds, opt => opt.MapFrom(src => src.Branches.Where(b => !b.IsDeleted).Select(b => b.Id).ToList()));
        }
    }
}
