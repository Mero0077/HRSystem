using AutoMapper;
using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Company.AddCompany.DTOs;
using HRSystem.Features.Company.AddCompany.Queries;
using MediatR;

namespace HRSystem.Features.Company.AddCompany.Command
{
    public record AddCompanyCommand(AddCompanyDTO AddCompanyDTO):IRequest<RequestResult<AddCompanyResponseDTO>>;
    public class AddCompanyCommandHandler : RequestHandlerBase<AddCompanyCommand, AddCompanyResponseDTO>
    {
        private IGeneralRepository<HRSystem.Models.Company> _CompanyRepository;
        public AddCompanyCommandHandler(IGeneralRepository<HRSystem.Models.Company> generalRepository ,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _CompanyRepository = generalRepository;
        }

        public override async Task<RequestResult<AddCompanyResponseDTO>> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;

            var exists = await mediator.Send(new CheckIfCompanyAlreadyExistsQuery(request.AddCompanyDTO.Name));
            if (!exists.IsSuccess) return RequestResult<AddCompanyResponseDTO>.Failure("already exists", ErrorCodes.AlreadyExists);

         var res= await _CompanyRepository.AddAsync(mapper.Map<HRSystem.Models.Company>(request.AddCompanyDTO));
            res.OrganizationId = userStateOrganizationId;
             return res!=null?
                RequestResult<AddCompanyResponseDTO>.Success(mapper.Map<AddCompanyResponseDTO>(res),"Company added"):
                RequestResult<AddCompanyResponseDTO>.Failure("Could not add company",ErrorCodes.AlreadyExists);

        }
    }
}
