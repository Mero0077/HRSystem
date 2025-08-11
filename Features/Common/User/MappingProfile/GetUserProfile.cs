using AutoMapper;
using HRSystem.Features.Common.User.GetUser;

namespace HRSystem.Features.Common.User.MappingProfile
{
    public class GetUserProfile:Profile
    {
        public GetUserProfile()
        {
            CreateMap<HRSystem.Models.User, GetUserResposneVM>();
        }
    }
}
