using AutoMapper;
using HRSystem.Features.Common.Branch.GetBranchByIdQuery.DTOs;

namespace HRSystem.Features.Common.Branch.GetBranchByIdQuery.Mapping_Profile
{
    public class GetBranchByIdQueryProfile : Profile
    {
        public GetBranchByIdQueryProfile() 
        {
            CreateMap<Models.Branch, GetBranchByIdQueryResponseDTO>()
                .ForMember(des => des.OrganizationId, opt => opt.MapFrom(src => src.Company.OrganizationId))
                .ForMember(des => des.DepartmentIds, opt => opt.MapFrom(src=>src.Departments.Select(e=>e.Id)));
        }
    }
}
