using AutoMapper;
using HRSystem.Features.Common.Department.DeleteDepartmentById.DTOs;
using HRSystem.Features.Common.Department.GetDepartmentById.DTOs;

namespace HRSystem.Features.Common.Department.DeleteDepartmentById.Mapping_profile
{
    public class DeleteDepartmentByIdProfile : Profile
    {
        public DeleteDepartmentByIdProfile() 
        {
            CreateMap<GetDepartmentByIdResponseDTO,DeleteDepartmentByIdQueryResponseDTO>();
        }
    }
}
