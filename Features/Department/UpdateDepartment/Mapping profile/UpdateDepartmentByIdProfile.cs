using AutoMapper;
using HRSystem.Features.Department.UpdateDepartment.DTOs;

namespace HRSystem.Features.Department.UpdateDepartment.Mapping_profile
{
    public class UpdateDepartmentByIdProfile : Profile
    {
        public UpdateDepartmentByIdProfile() 
        {
            CreateMap<Models.Department,UpdateDepartmentByIdResponseDTO>();
        }
    }
}
