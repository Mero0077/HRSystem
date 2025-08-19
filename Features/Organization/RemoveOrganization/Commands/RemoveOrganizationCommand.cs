using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Organization.RemoveOrganization.DTOs;
using MediatR;

namespace HRSystem.Features.Organization.RemoveOrganization.Commands
{
    public record RemoveOrganizationCommand(RemoveOrganizationDTO RemoveOrganizationDTO):IRequest<RequestResult<RemoveOrganizationResponseVM>>;
    public class DeleteOrganizationCommandHandler : RequestHandlerBase<RemoveOrganizationCommand, RemoveOrganizationResponseVM>
    {
        private IGeneralRepository<HRSystem.Models.Organization> _OrganizationRepository;
        public DeleteOrganizationCommandHandler(IGeneralRepository<HRSystem.Models.Organization> OrganizationRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _OrganizationRepository = OrganizationRepository;
        }

        public override async Task<RequestResult<RemoveOrganizationResponseVM>> Handle(RemoveOrganizationCommand request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;

            var res = await _OrganizationRepository.DeleteAsync(request.RemoveOrganizationDTO.Id, userStateOrganizationId);
            return (res.IsDeleted)?
                RequestResult<RemoveOrganizationResponseVM>.Success(mapper.Map<RemoveOrganizationResponseVM>(res), "Organization deleted!"):
                RequestResult<RemoveOrganizationResponseVM>.Failure("Organization already deleted!",ErrorCodes.AlreadyDeleted);
        }
    }
}
