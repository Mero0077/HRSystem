using AutoMapper;
using HRSystem.Features.Common.Department.IsDepartmentAlreadyAssignedToBranch.DTO;
using HRSystem.Features.Department.AssignDepartmentToBranch.DTOs;
using HRSystem.Features.Department.AssignDepartmentToBranch.VMs;

namespace HRSystem.Features.Department.AssignDepartmentToBranch.MappingProfile
{
    public class AssignDepartmentToBranchProfile:Profile
    {
        public AssignDepartmentToBranchProfile()
        {
            CreateMap<AssignDepartmentToBranchRequestVM, AssignDepartmentToBranchRequestDTO>();
            CreateMap<Models.Department, AssignDepartmentToBranchResponseDTO>();
            CreateMap<AssignDepartmentToBranchResponseDTO, AssignDepartmentToBranchResponseVM>();
            CreateMap<AssignDepartmentToBranchRequestDTO, IsDepartmentAlreadyAssignedToBranchRequestDTO>();
        }
    }
}
