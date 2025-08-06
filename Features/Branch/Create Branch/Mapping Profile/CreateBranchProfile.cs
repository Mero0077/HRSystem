using AutoMapper;
using HRSystem.Features.Branch.Create_Branch.DTOS;
using HRSystem.Models;

namespace HRSystem.Features.Branch.Create_Branch.Mapping_Profile
{
    public class CreateBranchProfile : Profile
    {
        public CreateBranchProfile() 
        {
            CreateMap<CreateBranchRequestViewModel,CreateBranchRequestDTO>();
            CreateMap<CreateBranchRequestDTO, Models.Branch>();
            CreateMap<Models.Branch, CreateBranchResponseDTO>().ReverseMap();
            CreateMap<Models.Branch, CreateBranchResponseViewModel>();
        }
    }
}
