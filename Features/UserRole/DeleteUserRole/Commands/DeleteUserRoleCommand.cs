using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.UserRole.DeleteUserRole.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.UserRole.DeleteUserRole.Commands
{
    public record DeleteUserRoleCommand(DeleteUserRoleDTO DeleteUserRoleDTO):IRequest<RequestResult<bool>>;
    public class DeleteUserRoleCommandHandler : RequestHandlerBase<DeleteUserRoleCommand, bool>
    {
        private IGeneralRepository<HRSystem.Models.UserRole> _UserRoleRepository;
        public DeleteUserRoleCommandHandler(IGeneralRepository<HRSystem.Models.UserRole> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _UserRoleRepository = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
          var UserRoles= await _UserRoleRepository.Get(e => e.UserId == request.DeleteUserRoleDTO.UserId && e.RoleId == request.DeleteUserRoleDTO.RoleId).ToListAsync();
          var res= await _UserRoleRepository.DeleteAsyncMass(UserRoles);
            return !res ?
                RequestResult<bool>.Failure("Could not delete roles!") :
                RequestResult<bool>.Success(true, "roles deleted successfully!");
        }
    }
}
