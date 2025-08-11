using AutoMapper;
using HRSystem.Features.EndPoints.GetEndPoint.DTO;
using HRSystem.Models;

namespace HRSystem.Features.EndPoints.GetEndPoint.MappingProfile
{
    public class GetEndPointProfile:Profile
    {
        public GetEndPointProfile()
        {
            CreateMap<EndPointRequestVM,EndPointDTO>();
            CreateMap<EndPointDTO, EndPointAction > ();
            CreateMap<EndPointAction, EndPointResponseVM > ();
        }
    }
}
