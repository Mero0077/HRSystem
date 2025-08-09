using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Role.Queries;
using HRSystem.Features.Role.RemoveRole.DTOs;
using HRSystem.Features.UserRole.AssignRoleToUser.Queries;
using HRSystem.Models;
using MediatR;

namespace HRSystem.Features.Role.RemoveRole.Command
{
    public record RemoveRoleCommand(RemoveRoleDTO RemoveRoleDTO):IRequest<RequestResult<RemoveRoleResponseVM>>;
    public class RemoveRoleCommandHandler : RequestHandlerBase<RemoveRoleCommand, RemoveRoleResponseVM>
    {
        private IGeneralRepository<HRSystem.Models.Role> _RoleRepository;
        public RemoveRoleCommandHandler(IGeneralRepository<HRSystem.Models.Role> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
             _RoleRepository = generalRepository;
        }

        public override async Task<RequestResult<RemoveRoleResponseVM>> Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {
            var exists= await mediator.Send(new IsRoleExistsQuery(request.RemoveRoleDTO.RoleId));
            if (!exists.IsSuccess) return RequestResult<RemoveRoleResponseVM>.Failure("Role does not exist!",ErrorCodes.NotFound);

            var assigned= await mediator.Send(new IsRoleAlreadyAssignedToAUserQuery(request.RemoveRoleDTO.RoleId));
            if (assigned) return RequestResult<RemoveRoleResponseVM>.Failure("This role cant be deleted as it is assigend to a user!");

          var res= await _RoleRepository.HardDeleteAsync(request.RemoveRoleDTO.RoleId);
                   await _RoleRepository.SaveChangesAsync();

            return res ?
                      RequestResult<RemoveRoleResponseVM>.Success(mapper.Map<RemoveRoleResponseVM>(request.RemoveRoleDTO)) :
                      RequestResult<RemoveRoleResponseVM>.Failure("Role could not be deleted!");
        }
    }
}
