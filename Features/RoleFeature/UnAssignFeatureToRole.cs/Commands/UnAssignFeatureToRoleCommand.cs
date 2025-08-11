using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Feature.Queries;
using HRSystem.Features.Common.Role.Queries;
using HRSystem.Features.Common.RoleFeature.Queries;
using HRSystem.Features.RoleFeature.UnAssignFeatureToRole.cs.DTOs;
using MediatR;

namespace HRSystem.Features.RoleFeature.UnAssignFeatureToRole.cs.Commands
{
    public record UnAssignFeatureToRoleCommand(UnAssignFeatureToRoleRequestDTO UnAssignFeatureToRoleRequestDTO) : IRequest<RequestResult<bool>>;
    public class UnAssignFeatureToRoleCommandHandler : RequestHandlerBase<UnAssignFeatureToRoleCommand, bool>
    {
        private readonly IGeneralRepository<Models.RoleFeature> _roleFeatureRepository;

        public UnAssignFeatureToRoleCommandHandler(IGeneralRepository<Models.RoleFeature> roleFeatureRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._roleFeatureRepository = roleFeatureRepository;
        }

        public override async Task<RequestResult<bool>> Handle(UnAssignFeatureToRoleCommand request, CancellationToken cancellationToken)
        {
            var resultRole = await mediator.Send(new IsRoleExistsQuery(request.UnAssignFeatureToRoleRequestDTO.RoleId));
            if (!resultRole.IsSuccess)
                return resultRole;

            var resultFeature = await mediator.Send(new IsFeatureExistsQuery(request.UnAssignFeatureToRoleRequestDTO.FeatureId));
            if(!resultFeature.IsSuccess)
                return resultFeature;

            var featureRoleCheck = await mediator.Send(new CheckFeatureRoleByIdsQuery(request.UnAssignFeatureToRoleRequestDTO.FeatureId,request.UnAssignFeatureToRoleRequestDTO.RoleId));
            if (!featureRoleCheck.Data)
                return RequestResult<bool>.Failure("The role isn't assigned to feature",ErrorCodes.NotFound);


            var entity = await _roleFeatureRepository.GetOneWithTrackingAsync(e=>e.RoleId == request.UnAssignFeatureToRoleRequestDTO.RoleId && e.FeatureId==request.UnAssignFeatureToRoleRequestDTO.FeatureId);

            await _roleFeatureRepository.DeleteAsync(entity.Id);
            await _roleFeatureRepository.SaveChangesAsync();
            return RequestResult<bool>.Success(true);
        }
    }
}
