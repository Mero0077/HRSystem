using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Role.Queries;
using HRSystem.Features.Common.RoleFeature.Queries;
using HRSystem.Features.RoleFeature.AssignListFeaturesToRoleCommandHandler.DTOs;
using HRSystem.Models;
using MediatR;

namespace HRSystem.Features.RoleFeature.AssignListFeaturesToRoleCommandHandler.Commands
{
    public record AssignListFeaturesToRoleCommand(AssignListFeaturesToRoleRequestDTO AssignListFeaturesToRoleRequestDTO) : IRequest<RequestResult<bool>>;
    public class AssignListFeaturesToRoleCommandHandler : RequestHandlerBase<AssignListFeaturesToRoleCommand, bool>
    {
        private readonly IGeneralRepository<Models.RoleFeature> _roleFeatureRepository;

        public AssignListFeaturesToRoleCommandHandler(IGeneralRepository<Models.RoleFeature> roleFeatureRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._roleFeatureRepository = roleFeatureRepository;
        }

        public  override async Task<RequestResult<bool>> Handle(AssignListFeaturesToRoleCommand request, CancellationToken cancellationToken)
        {
            var resultRole = await mediator.Send(new IsRoleExistsQuery(request.AssignListFeaturesToRoleRequestDTO.RoleId));
            if (!resultRole.IsSuccess)
                return resultRole;

            var newRoleFeatureList =new List<Models.RoleFeature>();

            foreach(var featureId in request.AssignListFeaturesToRoleRequestDTO.FeatureIds)
            {
               var result = await mediator.Send(new CheckFeatureRoleByIdsQuery(featureId,request.AssignListFeaturesToRoleRequestDTO.RoleId));
                if(result.Data)
                    continue;

                newRoleFeatureList.Add(new Models.RoleFeature
                {
                    RoleId = request.AssignListFeaturesToRoleRequestDTO.RoleId,
                    FeatureId = featureId
                });
            }
            if (newRoleFeatureList.Any())
                await _roleFeatureRepository.AddAsyncRange(newRoleFeatureList);

            return RequestResult<bool>.Success(true);


        }
    }
}
