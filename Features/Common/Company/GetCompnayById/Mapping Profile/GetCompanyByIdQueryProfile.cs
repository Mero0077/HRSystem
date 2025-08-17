using AutoMapper;
using HRSystem.Features.Common.Company.GetCompnayByIdQuery.DTOs;

namespace HRSystem.Features.Common.Company.GetCompnayByIdQuery.Mapping_Profile
{
    public class GetCompanyByIdQueryProfile : Profile
    {
        public GetCompanyByIdQueryProfile() 
        {
            CreateMap<Models.Company, GetCompanyByIdQueryResponseDTO>()
                .ForMember(des => des.BranchIds, opt => opt.MapFrom(src => src.Branches.Select(e => e.Id).ToList()));
        }
    }
}
