using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Organization.AddOrganization.DTOs;
using MediatR;

namespace HRSystem.Features.Organization.AddOrganization.Commands
{
    public record AddOrganizationCommand(AddOrganizationDTO AddOrganizationDTO):IRequest<RequestResult<AddOrganizationReponseVM>>;
    public class AddOrganizationCommandHandler : RequestHandlerBase<AddOrganizationCommand, AddOrganizationReponseVM>
    {
        private IGeneralRepository<HRSystem.Models.Organization> _OrganizationRepository;
        public AddOrganizationCommandHandler(IGeneralRepository<HRSystem.Models.Organization> OrganizationRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _OrganizationRepository = OrganizationRepository;
        }

        public override async Task<RequestResult<AddOrganizationReponseVM>> Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
        {
           var res= await _OrganizationRepository.AddAsync(mapper.Map<HRSystem.Models.Organization>(request.AddOrganizationDTO));
            await _OrganizationRepository.SaveChangesAsync();
           var response = mapper.Map<AddOrganizationReponseVM>(res);
           return RequestResult<AddOrganizationReponseVM>.Success(response);
        }
    }
}
