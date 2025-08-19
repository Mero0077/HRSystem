using AutoMapper;
using HRSystem.Features.Branch.AssignBranchToCompany.DTOs;
using HRSystem.Features.Branch.AssignBranchToCompany.VMs;

namespace HRSystem.Features.Branch.AssignBranchToCompany.MappingProfile
{
    public class AssignBranchToCompanyProfile:Profile
    {
        public AssignBranchToCompanyProfile()
        {
            CreateMap<AssignBranchToCompanyRequestVM, AssignBranchToCompanyRequestDTO>();
            CreateMap<Models.Branch, AssignBranchToCompanyResponseDTO>();
            CreateMap<AssignBranchToCompanyResponseDTO, AssignBranchToCompanyRequestVM>();
        }
    }
}
