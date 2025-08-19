using AutoMapper;
using HRSystem.Features.Auth.Login.DTO;

namespace HRSystem.Features.Auth.Login.MappingProfile
{
    public class LoginProfile:Profile
    {
        public LoginProfile()
        {
            CreateMap<LoginRequestVM, LoginDTO>();
            CreateMap<LoginResponseDTOs,LoginResponseVM>();
           
        }
    }
}
