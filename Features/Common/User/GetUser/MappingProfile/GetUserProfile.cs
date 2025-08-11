using AutoMapper;
using HRSystem.Features.Common.User.GetUser;

namespace HRSystem.Features.Common.User.GetUser.MappingProfile
{
    public class GetUserProfile:Profile
    {
        public GetUserProfile()
        {
            CreateMap<Models.User, GetUserResposneVM>();
        }
    }
}
