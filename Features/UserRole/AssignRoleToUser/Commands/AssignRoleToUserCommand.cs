using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Common;
using HRSystem.Features.Role.AssignRoleToUser.Queries;
using HRSystem.Features.Common.Role.Queries


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
            var RoleExists = await mediator.Send(new IsRoleExistsQuery(request.AssignRoleToUserDTO.RoleId));
            if (!RoleExists.IsSuccess) return RequestResult<AssignRoleToUserResponseVM>.Failure("Role does not exist!");

            var UserExists = await mediator.Send(new IsUserExistsQuery(request.AssignRoleToUserDTO.UserId));
            if (!UserExists.IsSuccess) return RequestResult<AssignRoleToUserResponseVM>.Failure("User does not exist!");


            var alreadyAssigned = await mediator.Send(new IsUserAlreadyAssignedToThisRoleQuery(request.AssignRoleToUserDTO));
            if (alreadyAssigned.IsSuccess) return RequestResult<AssignRoleToUserResponseVM>.Failure("Role is already assigned!", ErrorCodes.AlreadyExists);

            var res = await _userRoleRepository.AddAsync(mapper.Map<Models.UserRole>(request.AssignRoleToUserDTO));
            await _userRoleRepository.SaveChangesAsync();

            return res != null ?
                RequestResult<AssignRoleToUserResponseVM>.Success(mapper.Map<AssignRoleToUserResponseVM>(res), "Role assigned to user successfully!") :
                RequestResult<AssignRoleToUserResponseVM>.Failure("Role could not be assigned to user!", ErrorCodes.NoError);

        }
    }
}
