using HRSystem.Common.Views;
using HRSystem.Common;
using MediatR;
using HRSystem.Features.Common.User.Queries;
using HRSystem.Common.Enums;

namespace HRSystem.Features.Common.Role.Queries
{
    public record IsRoleExistsQuery(Guid RoleId) : IRequest<RequestResult<bool>>;
    public class IsRoleExistsQueryHandler : RequestHandlerBase<IsRoleExistsQuery, bool>
    {
        private IGeneralRepository<Models.Role> _RoleRepository;
        public IsRoleExistsQueryHandler(IGeneralRepository<Models.Role> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _RoleRepository = generalRepository;
        }


        public override async Task<RequestResult<bool>> Handle(IsRoleExistsQuery request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;
            var res = await _RoleRepository.GetOneByIdAsync(request.RoleId, userStateOrganizationId);
            bool exists = res != null;
            return exists ?
                RequestResult<bool>.Success(exists) :
                RequestResult<bool>.Failure("Role does not exist",ErrorCodes.NotFound);
        }
    }
}
