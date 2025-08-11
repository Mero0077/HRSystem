using HRSystem.Common;
using HRSystem.Common.Views;
using MediatR;
using System.Globalization;

namespace HRSystem.Features.Organization.AddOrganization.Queries
{

    public record CheckIfOrganizationExistsQuery(String Name):IRequest<RequestResult<bool>>;
    public class CheckIfOrganizationExistsQueryHandler : RequestHandlerBase<CheckIfOrganizationExistsQuery, bool>
    {
        private IGeneralRepository<HRSystem.Models.Organization> _OrganizationRepository;
        public CheckIfOrganizationExistsQueryHandler(IGeneralRepository<HRSystem.Models.Organization> OrganizationRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _OrganizationRepository = OrganizationRepository;
        }

        public override async Task<RequestResult<bool>> Handle(CheckIfOrganizationExistsQuery request, CancellationToken cancellationToken)
        {
            var exists = await _OrganizationRepository.GetOneWithTrackingAsync(e=>e.Name== request.Name);
            return exists!=null? RequestResult<bool>.Success(true): RequestResult<bool>.Failure("not found") ;
        }
    }
}
