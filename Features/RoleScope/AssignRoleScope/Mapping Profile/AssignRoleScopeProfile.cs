using AutoMapper;
using HRSystem.Features.Common.Branch.GetBranchByIdQuery.DTOs;
using HRSystem.Features.Common.Company.GetCompnayByIdQuery.DTOs;
using HRSystem.Features.Common.Department.GetDepartmentById.DTOs;
using HRSystem.Features.Common.Organization.GetOrganizationWithChildren.DTOs;
using HRSystem.Features.RoleScope.AssignRoleScope.DTOs;

namespace HRSystem.Features.RoleScope.AssignRoleScope.Mapping_Profile
{
    public class AssignRoleScopeProfile : Profile
    {
        public AssignRoleScopeProfile() 
        {
            CreateMap<GetOrganizationWithChildrenResponseDTO, OrganizationHierarchyResponseDTO>()
                .ForMember(dest => dest.Companies, opt => opt.MapFrom(src => src.Companies));

            CreateMap<CompanyResponseDTO, CompanyHierarchyResponseDTO>();

            CreateMap<GetCompanyByIdQueryResponseDTO, CompanyHierarchyResponseDTO>();
            CreateMap<GetBranchByIdQueryResponseDTO, BranchHierarchyResponseDTO>();
            CreateMap<GetDepartmentByIdResponseDTO, DepartmentHierarchyResponseDTO>();

            CreateMap<AssignRoleScopeRequestViewModel, AssignRoleScopeRequestDTO>();
            CreateMap<AssignRoleScopeResponseDTO, AssignRoleScopeResponseViewModel>();

        }
    }
}
