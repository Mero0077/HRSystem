using AutoMapper;
using HRSystem.Features.Branch.Delete_Branch.DTOs;
using HRSystem.Features.Common.Branch.GetBranchByIdQuery.DTOs;

namespace HRSystem.Features.Common.Branch.Delete_Branch.Mapping_Profile
{
    public class DeleteBranchProfile : Profile
    {
        public DeleteBranchProfile() 
        {
            CreateMap<GetBranchByIdQueryResponseDTO,DeleteBranchResponseDTO>();
        }
    }
}
