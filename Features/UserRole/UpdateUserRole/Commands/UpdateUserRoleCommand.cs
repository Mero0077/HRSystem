using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.UserRole.AssignRoleToUser.Commands;
using HRSystem.Features.UserRole.AssignRoleToUser.DTOs;
using HRSystem.Features.UserRole.DeleteUserRole.Commands;
using HRSystem.Features.UserRole.DeleteUserRole.DTOs;
using HRSystem.Features.UserRole.UpdateUserRole;
using HRSystem.Features.UserRole.UpdateUserRole.DTOs;
using MediatR;

namespace HRSystem.Features.UserRole.UpdateUserRole.Commands
{
    public record UpdateUserRoleCommand(UpdateUserRoleDTO UpdateRoleDTO) : IRequest<RequestResult<UpdateUserRoleResponseVM>>;
    public class UpdateRoleCommandHandler : RequestHandlerBase<UpdateUserRoleCommand, UpdateUserRoleResponseVM>
    {
        private IGeneralRepository<Models.UserRole> _userRoleRepository;
        public UpdateRoleCommandHandler(IGeneralRepository<Models.UserRole> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _userRoleRepository = generalRepository;
        }

        public override async Task<RequestResult<UpdateUserRoleResponseVM>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
          var res=  await mediator.Send(new DeleteUserRoleCommand(mapper.Map<DeleteUserRoleDTO>(request.UpdateRoleDTO)));
          if(!res.IsSuccess) return RequestResult<UpdateUserRoleResponseVM>.Failure(HRSystem.Common.Enums.ErrorCodes.NotFound);

          var assigned = await mediator.Send(new AssignRoleToUserCommand(mapper.Map<AssignRoleToUserDTO>(request.UpdateRoleDTO)));
            return (!assigned.IsSuccess) ?
                  RequestResult<UpdateUserRoleResponseVM>.Failure("Could not be assigned!") :
                  RequestResult<UpdateUserRoleResponseVM>.Success(mapper.Map<UpdateUserRoleResponseVM>(assigned));
        }
    }
}
