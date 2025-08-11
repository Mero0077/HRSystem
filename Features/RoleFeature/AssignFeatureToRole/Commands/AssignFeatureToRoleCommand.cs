using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Feature.Queries;
using HRSystem.Features.Common.Role.Queries;
using HRSystem.Features.Common.RoleFeature.Queries;
using HRSystem.Features.RoleFeature.AssignFeatureToRole.DTOs;
using MediatR;

namespace HRSystem.Features.RoleFeature.AssignFeatureToRole.Commands
{
    public record AssignFeatureToRoleCommand(AssignFeatureToRoleRequestDTO AssignFeatureToRoleRequestDTO) : IRequest<RequestResult<bool>>;

    public class AssignFeatureToRoleCommandHandler : RequestHandlerBase<AssignFeatureToRoleCommand, bool>
    {
        private readonly HRSystem.Common.IGeneralRepository<Models.RoleFeature> _roleFeatureRepository;

        public AssignFeatureToRoleCommandHandler(IGeneralRepository<Models.RoleFeature> roleFeatureRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._roleFeatureRepository = roleFeatureRepository;
        }

        public override async Task<RequestResult<bool>> Handle(AssignFeatureToRoleCommand request, CancellationToken cancellationToken)
        {
           var roleResult= await mediator.Send(new IsRoleExistsQuery(request.AssignFeatureToRoleRequestDTO.RoleId));
            if (!roleResult.IsSuccess)
                return roleResult;

            var featureResult = await mediator.Send(new IsFeatureExistsQuery(request.AssignFeatureToRoleRequestDTO.FeatureId));
            if(!featureResult.IsSuccess)
                return featureResult;

            var featureRoleCheck = await mediator.Send(new CheckFeatureRoleByIdsQuery(request.AssignFeatureToRoleRequestDTO.FeatureId, request.AssignFeatureToRoleRequestDTO.RoleId));
            if (featureRoleCheck.Data)
                return RequestResult<bool>.Failure("The role is already assigned to feature", ErrorCodes.NotFound);

            var roleFeatureMapped = mapper.Map<Models.RoleFeature>(request.AssignFeatureToRoleRequestDTO);
            await _roleFeatureRepository.AddAsync(roleFeatureMapped);
            await _roleFeatureRepository.SaveChangesAsync();
            return RequestResult<bool>.Success(true);

        }
    }


}
