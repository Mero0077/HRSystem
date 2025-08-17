using AutoMapper;
using HRSystem.Features.Common.User.GetUser;
using HRSystem.Features.Common.User.GetUserById.DTO;

namespace HRSystem.Features.Common.User.GetUser.MappingProfile
{
    public class GetUserByIdQueryProfile:Profile
    {
        public GetUserByIdQueryProfile()
        {
            CreateMap<Models.User, GetUserByIdResponseDTO>();
        }
    }
}
