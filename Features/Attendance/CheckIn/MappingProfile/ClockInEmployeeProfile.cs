using AutoMapper;
using HRSystem.Features.Attendance.CheckIn.ClockInEmployee.DTOs;
using HRSystem.Features.Attendance.CheckIn.ClockInEmployee.VMs;

namespace HRSystem.Features.Attendance.CheckIn.MappingProfile
{
    public class ClockInEmployeeProfile:Profile
    {
        public ClockInEmployeeProfile()
        {
            CreateMap<ClockInEmployeeRequestVM, ClockInEmployeeRequestDTO>();
            CreateMap<ClockInEmployeeRequestDTO,Models.Attendance >();
            CreateMap<Models.Attendance, ClockInEmployeeResponseDTO>();
            CreateMap<ClockInEmployeeResponseDTO,ClockInEmployeeResponseVm >();

        }
    }
}
