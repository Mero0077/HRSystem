using AutoMapper;
using HRSystem.Features.UserScope.GetUserScope.DTOs;
using HRSystem.Features.UserScope.GetUserScope.VMs;

namespace HRSystem.Features.UserScope.GetUserScope.MappingProfile
{
    public class GetUserScopeProfile:Profile
    {
        public GetUserScopeProfile()
        {
            CreateMap<GetUserScopeRequestVM, GetUserScopeRequestDTO>();
            CreateMap<Models.UserScope, GetUserScopeResponseDTO>();
            CreateMap<GetUserScopeResponseDTO, GetUserScopeResponseVM>();
        }
    }
}
