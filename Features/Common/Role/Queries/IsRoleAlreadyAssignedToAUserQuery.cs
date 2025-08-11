using HRSystem.Common;
using HRSystem.Common.Views;
using MediatR;

namespace HRSystem.Features.Common.Role.Queries
{
    public record IsRoleAlreadyAssignedToAUserQuery(Guid RoleId):IRequest<bool>;
    public class IsRoleAlreadyAssignedToAUserQueryHandler : IRequestHandler<IsRoleAlreadyAssignedToAUserQuery, bool>
    {
        private IGeneralRepository<HRSystem.Models.UserRole> _UserRoleRepository;
        public IsRoleAlreadyAssignedToAUserQueryHandler(IGeneralRepository<HRSystem.Models.UserRole> generalRepository, RequestHandlerBaseParameters parameters)
        {
            _UserRoleRepository = generalRepository;
        }

        public async Task<bool> Handle(IsRoleAlreadyAssignedToAUserQuery request, CancellationToken cancellationToken)
        {
            return await _UserRoleRepository.AnyAsync(e => e.RoleId == request.RoleId && e.UserId != null);
        }
    }
}
