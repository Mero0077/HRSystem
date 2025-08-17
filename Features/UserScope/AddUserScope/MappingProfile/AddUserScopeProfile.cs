using AutoMapper;
using HRSystem.Features.UserScope.AddUserScope.DTOs;
using HRSystem.Features.UserScope.AddUserScope.VMs;

namespace HRSystem.Features.UserScope.AddUserScope.MappingProfile
{
    public class AddUserScopeProfile:Profile
    {
        public AddUserScopeProfile()
        {
            CreateMap<AddUserScopeRequestVM, AddUserScopeRequestDTO>();
            CreateMap<AddUserScopeRequestDTO,HRSystem.Models.UserScope >();
            CreateMap<HRSystem.Models.UserScope, AddUserScopeResponseDTO>();
            CreateMap<AddUserScopeResponseDTO, AddUserScopeResponseVM>();
        }
    }
}
