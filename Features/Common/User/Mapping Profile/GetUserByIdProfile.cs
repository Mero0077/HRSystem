using AutoMapper;
using HRSystem.Features.Branch.Create_Branch.Command;
using HRSystem.Features.Common.User.DTOs;

namespace HRSystem.Features.Common.User.Mapping_Profile
{
    public class GetUserByIdProfile : Profile
    {
       public GetUserByIdProfile() 
        {
            CreateMap<Models.User,GetUserByIdResponseDTO>()
                .ForMember(des=>des.RoleIds,opt=>opt.MapFrom(src=>src.UserRole.Select(e=>e.RoleId)));
        }
    }
}
