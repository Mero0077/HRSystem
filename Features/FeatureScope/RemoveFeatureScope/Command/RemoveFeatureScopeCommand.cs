using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.FeatureScope.AddFeatureScope.DTOs;
using HRSystem.Features.FeatureScope.AddFeatureScope.Query;
using HRSystem.Features.FeatureScope.GetFeatureScope.DTOs;
using HRSystem.Features.FeatureScope.GetFeatureScope.Query;
using HRSystem.Features.FeatureScope.RemoveFeatureScope.DTOs;
using MediatR;
using MediatR.Wrappers;

namespace HRSystem.Features.FeatureScope.RemoveFeatureScope.Command
{
    public record RemoveFeatureScopeCommand(RemoveFeatureScopeRequestDTO RemoveFeatureScopeRequestDTO):IRequest<RequestResult<RemoveFeatureScopeResponseDTO>>;
    public class RemoveFeatureScopeCommandHandler : RequestHandlerBase<RemoveFeatureScopeCommand, RemoveFeatureScopeResponseDTO>
    {
        private IGeneralRepository<HRSystem.Models.FeatureScope> _FeatureScopeepository;
        public RemoveFeatureScopeCommandHandler(IGeneralRepository<HRSystem.Models.FeatureScope> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _FeatureScopeepository = generalRepository;
        }

        public override async Task<RequestResult<RemoveFeatureScopeResponseDTO>> Handle(RemoveFeatureScopeCommand request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;


            var exists = await mediator.Send(new GetFeatureScopeQuery(mapper.Map<GetFeatureScopeRequestDTO>(request.RemoveFeatureScopeRequestDTO.FeatureId)));
            if (exists.IsSuccess) return RequestResult<RemoveFeatureScopeResponseDTO>.Failure(exists.Message);

            var res = await _FeatureScopeepository.DeleteAsync(request.RemoveFeatureScopeRequestDTO.FeatureId, userStateOrganizationId);
            await _FeatureScopeepository.SaveChangesAsync();

            return RequestResult<RemoveFeatureScopeResponseDTO>.Success(mapper.Map<RemoveFeatureScopeResponseDTO>(res));
        }
    }
}
