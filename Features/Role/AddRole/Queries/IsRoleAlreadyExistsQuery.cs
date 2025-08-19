using HRSystem.Common;
using HRSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Role.AddRole.Queries
{
    public record IsRoleAlreadyExistsQuery(string Name):IRequest<RequestResult<bool>>;
    public class IsRoleAlreadyExistsQueryHandler : RequestHandlerBase<IsRoleAlreadyExistsQuery, bool>
    {
        private IGeneralRepository<HRSystem.Models.Role> _RoleRepository;

        public IsRoleAlreadyExistsQueryHandler(IGeneralRepository<HRSystem.Models.Role> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _RoleRepository = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(IsRoleAlreadyExistsQuery request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;

            var exists = await _RoleRepository.Get(e => e.Name == request.Name, userStateOrganizationId).FirstOrDefaultAsync(cancellationToken);
            return exists != null ?
                RequestResult<bool>.Failure("Role does not exist") :
                RequestResult<bool>.Success(true);

        }
    }
}
