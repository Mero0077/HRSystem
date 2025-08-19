using AutoMapper;
using HRSystem.Features.Branch.AssignBranchToCompany.DTOs;
using HRSystem.Features.Common.Branch.IsBranchAlreadyAssignedToCompany.DTOs;

namespace HRSystem.Features.Common.Branch.IsBranchAlreadyAssignedToCompany.MappingProfile
{
    public class IsBranchAlreadyAssignedToCompanyProfile:Profile
    {
        public IsBranchAlreadyAssignedToCompanyProfile()
        {
            CreateMap<AssignBranchToCompanyResponseDTO, IsBranchAlreadyAssignedToCompanyRequestDTO>();
        }
    }
}
