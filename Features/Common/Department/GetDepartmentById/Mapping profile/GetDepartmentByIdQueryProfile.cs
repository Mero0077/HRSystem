using AutoMapper;
using HRSystem.Features.Common.Department.GetDepartmentById.DTOs;

namespace HRSystem.Features.Common.Department.GetDepartmentById.Mapping_profile
{
    public class GetDepartmentByIdQueryProfile : Profile
    {
        public GetDepartmentByIdQueryProfile() 
        {
            CreateMap<Models.Department, GetDepartmentByIdResponseDTO>()
         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
         .ForMember(dest => dest.NumOfEmployees, opt => opt.MapFrom(src => src.NumOfEmployees))
         .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
         .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.BranchId))
         .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Branch.CompanyId))
         .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.Branch.Company.OrganizationId));

        }
    }
}
