using AutoMapper;
using HRSystem.Features.Auth.Refresh_Token.DTOs;

namespace HRSystem.Features.Auth.Refresh_Token.Mapping_Profile
{
    public class RefreshTokenProfile : Profile
    {
        public RefreshTokenProfile() 
        {
            CreateMap<RefreshTokenRequestViewModel,RefreshTokenRequestDTO>();
            CreateMap<RefreshTokenResponseDTO, RefreshTokenResponseViewModel>();
        }
    }
}
