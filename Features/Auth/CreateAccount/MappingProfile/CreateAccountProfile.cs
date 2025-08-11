using AutoMapper;
using HRSystem.Features.Auth.CreateAccount.DTO;

namespace HRSystem.Features.Auth.CreateAccount.MappingProfile
{
    public class CreateAccountProfile:Profile
    {
        public CreateAccountProfile()
        {
            CreateMap<CreateAccountRequestVM, CreateAccountDTO>();
            CreateMap<CreateAccountDTO, HRSystem.Models.User>();
            CreateMap<HRSystem.Models.User, CreateAccountResponseVM>();
        }
    }
}
