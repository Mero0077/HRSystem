using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Common;
using HRSystem.Features.UserRole.AssignRoleToUser.Queries;
using HRSystem.Features.Common.Role.Queries;


using MediatR;
using HRSystem.Features.Common.User.Queries;
using HRSystem.Features.UserRole.AssignRoleToUser;
using HRSystem.Features.UserRole.AssignRoleToUser.DTOs;

namespace HRSystem.Features.UserRole.AssignRoleToUser.Commands
{
    public record AssignRoleToUserCommand(AssignRoleToUserDTO AssignRoleToUserDTO) : IRequest<RequestResult<AssignRoleToUserResponseVM>>;
    public class AssignRoleToUserCommandHandler : RequestHandlerBase<AssignRoleToUserCommand, AssignRoleToUserResponseVM>
    {
        private IGeneralRepository<Models.UserRole> _userRoleRepository;
        public AssignRoleToUserCommandHandler(IGeneralRepository<Models.UserRole> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _userRoleRepository = generalRepository;
        }

        public override async Task<RequestResult<AssignRoleToUserResponseVM>> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
        {
            foreach (var roleId in request.AssignRoleToUserDTO.RoleIds.Distinct())
            {
                var roleCheck = await mediator.Send(new IsRoleExistsQuery(roleId));
                if (!roleCheck.IsSuccess) return RequestResult<AssignRoleToUserResponseVM>.Failure($"Role {roleId} does not exist!");
            }


            var userCheck = await mediator.Send(new IsUserExistsQuery(request.AssignRoleToUserDTO.UserId));
            if (!userCheck.IsSuccess) return RequestResult<AssignRoleToUserResponseVM>.Failure("User does not exist!");


            var alreadyAssigned = await mediator.Send(new IsUserAlreadyAssignedToThisRoleQuery(request.AssignRoleToUserDTO));
            if (alreadyAssigned.IsSuccess) return RequestResult<AssignRoleToUserResponseVM>.Failure("Role is already assigned!", ErrorCodes.AlreadyExists);

            var userRoles = request.AssignRoleToUserDTO.RoleIds.Select(roleid => new HRSystem.Models.UserRole
            {
                UserId=request.AssignRoleToUserDTO.UserId,
                RoleId= roleid
            }).ToList();

            var res = await _userRoleRepository.AddAsyncRange(userRoles);
            await _userRoleRepository.SaveChangesAsync();

            var mapped = new AssignRoleToUserResponseVM
            {
                UserId = request.AssignRoleToUserDTO.UserId,
                RoleIds = userRoles.Select(e => e.RoleId).ToList(),
            };

            return res != null ?
                RequestResult<AssignRoleToUserResponseVM>.Success(mapper.Map<AssignRoleToUserResponseVM>(mapped), "Role assigned to user successfully!") :
                RequestResult<AssignRoleToUserResponseVM>.Failure("Role could not be assigned to user!", ErrorCodes.NoError);

        }
    }
}
