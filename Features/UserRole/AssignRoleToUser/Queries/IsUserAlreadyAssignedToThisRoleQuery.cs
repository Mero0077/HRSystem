using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.UserRole.AssignRoleToUser.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.UserRole.AssignRoleToUser.Queries
{
    public record IsUserAlreadyAssignedToThisRoleQuery(AssignRoleToUserDTO AssignRoleToUserDTO) : IRequest<RequestResult<bool>>;
    public class IsUserAlreadyAssignedToThisRoleQueryHandler : RequestHandlerBase<IsUserAlreadyAssignedToThisRoleQuery, bool>
    {
        private IGeneralRepository<Models.UserRole> _UserRoleRepository;
        public IsUserAlreadyAssignedToThisRoleQueryHandler(IGeneralRepository<Models.UserRole> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _UserRoleRepository = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(IsUserAlreadyAssignedToThisRoleQuery request, CancellationToken cancellationToken)
        {
            var res = await _UserRoleRepository.Get(e => e.UserId == request.AssignRoleToUserDTO.UserId && request.AssignRoleToUserDTO.RoleIds.Contains(e.RoleId)).ToListAsync();
            return res == null || res.Count==0?
                  RequestResult<bool>.Failure("Roles not assigend to this user") :
                  RequestResult<bool>.Success(true, "role is already assigend to user");
        }
    }
}
