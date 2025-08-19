using AutoMapper;
using HRSystem.Features.Common.UserRole.GetUserWithRole.DTO;

namespace HRSystem.Features.Common.UserRole.GetUserWithRole.Mapping_Profile
{
    public class GetUserWithRoleProfile : Profile
    {
        public GetUserWithRoleProfile() 
        {
            CreateMap<GetUserWithRoleDTO, UserWithRoleResponseDTO>();
        }
    }
}
