using AutoMapper;
using HRSystem.Features.Attendance.CheckOut.DTOs;
using HRSystem.Features.Attendance.CheckOut.VMs;

namespace HRSystem.Features.Attendance.CheckOut.MappingProfile
{
    public class CheckOutProfile:Profile
    {
        public CheckOutProfile()
        {
            CreateMap<CheckOutEmployeeRequestVM, CheckOutEmployeeRequestDTO>();
            CreateMap<CheckOutEmployeeRequestDTO, Models.Attendance>();
            CreateMap<Models.Attendance, CheckOutEmployeeResponseDTO>();
            CreateMap<CheckOutEmployeeResponseDTO, CheckOutEmployeeResponseVM>();
        }
    }
}
