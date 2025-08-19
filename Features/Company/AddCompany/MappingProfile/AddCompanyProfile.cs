using AutoMapper;
using HRSystem.Features.Company.AddCompany.DTOs;

namespace HRSystem.Features.Company.AddCompany.MappingProfile
{
    public class AddCompanyProfile:Profile
    {
        public AddCompanyProfile()
        {
            CreateMap<AddCompanyRequestVM,AddCompanyDTO>();
            CreateMap<AddCompanyDTO, HRSystem.Models.Company>();
            CreateMap<HRSystem.Models.Company,AddCompanyResponseDTO>();
        }
    }
}
