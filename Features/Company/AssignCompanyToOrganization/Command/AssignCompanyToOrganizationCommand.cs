using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Company.AssignCompanyToOrganization.DTOs;
using MediatR;

namespace HRSystem.Features.Company.AssignCompanyToOrganization.Command
{
    public record AssignCompanyToOrganizationCommand(AssignCompanyToOrganizationRequestDTO AssignCompanyToOrganizationRequestDTO):IRequest<RequestResult<AssignCompanyToOrganizationResponseDTO>>;
    public class AssignCompanyToOrganizationCommandHandler : RequestHandlerBase<AssignCompanyToOrganizationCommand, AssignCompanyToOrganizationResponseDTO>
    {
        private IGeneralRepository<Models.Company> _companyRepository;
        public AssignCompanyToOrganizationCommandHandler(IGeneralRepository<Models.Company> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _companyRepository = generalRepository;
        }

        public override async Task<RequestResult<AssignCompanyToOrganizationResponseDTO>> Handle(AssignCompanyToOrganizationCommand request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;

            var company = await _companyRepository.GetOneByIdAsync(request.AssignCompanyToOrganizationRequestDTO.CompanyId, userStateOrganizationId);
            if (company == null) return RequestResult<AssignCompanyToOrganizationResponseDTO>.Failure("Company does not exist");

            company.OrganizationId = request.AssignCompanyToOrganizationRequestDTO.OrganizationId;
            var res= await _companyRepository.UpdateAsync(company);
            await _companyRepository.SaveChangesAsync(cancellationToken);

            return RequestResult<AssignCompanyToOrganizationResponseDTO>.Success(mapper.Map<AssignCompanyToOrganizationResponseDTO>(res));
        }
    }
}
