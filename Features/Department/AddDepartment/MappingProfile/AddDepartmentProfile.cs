using AutoMapper;
using HRSystem.Features.Department.AddDepartment.DTOs;
using HRSystem.Features.Department.AddDepartment.VMs;

namespace HRSystem.Features.Department.AddDepartment.MappingProfile
{
    public class AddDepartmentProfile:Profile
    {
        public AddDepartmentProfile()
        {
            CreateMap<AddDepartmentRequestVM, AddDepartmentResponseDTO>();
            CreateMap<AddDepartmentResponseDTO,Models.Department>();
            CreateMap<Models.Department, AddDepartmentResponseDTO>();
            CreateMap<AddDepartmentResponseDTO,AddDepartmentResponseVM >();
        }
    }
}
