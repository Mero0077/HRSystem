using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Role.AssignRoleToUser.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Role.AssignRoleToUser.Queries
{
    public record IsUserAlreadyAssignedToThisRoleQuery(AssignRoleToUserDTO AssignRoleToUserDTO):IRequest<RequestResult<bool>>;
    public class IsUserAlreadyAssignedToThisRoleQueryHandler : RequestHandlerBase<IsUserAlreadyAssignedToThisRoleQuery, bool>
    {
        private IGeneralRepository<HRSystem.Models.UserRole> _UserRoleRepository;
        public IsUserAlreadyAssignedToThisRoleQueryHandler(IGeneralRepository<HRSystem.Models.UserRole> generalRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _UserRoleRepository = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(IsUserAlreadyAssignedToThisRoleQuery request, CancellationToken cancellationToken)
        {
          var res= await _UserRoleRepository.Get(e => e.UserId == request.AssignRoleToUserDTO.UserId && e.RoleId == request.AssignRoleToUserDTO.RoleId).FirstOrDefaultAsync();
            return res == null ?
                  RequestResult<bool>.Failure("Role not assigend to this user") :
                  RequestResult<bool>.Success(true,"role is already assigend to user");
        }
    }
}
