using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Role.AddRole.DTOs;
using HRSystem.Features.Role.AddRole.Queries;
using MediatR;

namespace HRSystem.Features.Role.AddRole.Commands
{
    public record AddRoleCommand(AddRoleDTO AddRoleDTO):IRequest<RequestResult<AddRoleResponseVM>>;
    public class AddRoleCommandHandler : RequestHandlerBase<AddRoleCommand, AddRoleResponseVM>
    {
        private IGeneralRepository<HRSystem.Models.Role> _RoleRepository;

        public AddRoleCommandHandler(IGeneralRepository<HRSystem.Models.Role>  generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _RoleRepository = generalRepository;
        }

        public override async Task<RequestResult<AddRoleResponseVM>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
           var exists = await mediator.Send(new IsRoleAlreadyExistsQuery(request.AddRoleDTO.Name));
           if(!exists.IsSuccess) return RequestResult<AddRoleResponseVM>.Failure("Role could not be added!", ErrorCodes.AlreadyExists);

            var res= await _RoleRepository.AddAsync(mapper.Map<HRSystem.Models.Role>(request.AddRoleDTO));
            await _RoleRepository.SaveChangesAsync();
            return res != null ?
                RequestResult<AddRoleResponseVM>.Success(mapper.Map<AddRoleResponseVM>(res), "Role added") :
                RequestResult<AddRoleResponseVM>.Failure("Role could not be added!", ErrorCodes.AlreadyExists);
        }
    }
}
