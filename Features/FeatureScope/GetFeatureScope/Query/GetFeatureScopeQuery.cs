using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Feature.GetAllFeature.DTOs;
using HRSystem.Features.FeatureScope.GetFeatureScope.DTOs;
using MediatR;

namespace HRSystem.Features.FeatureScope.GetFeatureScope.Query
{
    public record GetFeatureScopeQuery(GetFeatureScopeRequestDTO getFeatureScopeRequestDTO) :IRequest<RequestResult<GetAllFeaturesResponseDTO>>;
    public class GetFeatureScopeQueryHandler : RequestHandlerBase<GetFeatureScopeQuery, GetAllFeaturesResponseDTO>
    {
        private IGeneralRepository<HRSystem.Models.FeatureScope> _repository;
        public GetFeatureScopeQueryHandler(IGeneralRepository<HRSystem.Models.FeatureScope> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _repository = generalRepository;
        }

        public override async Task<RequestResult<GetAllFeaturesResponseDTO>> Handle(GetFeatureScopeQuery request, CancellationToken cancellationToken)
        {
            var res = await _repository.GetOneByIdAsync(request.getFeatureScopeRequestDTO.FeatureId);
            return res!=null ?
                    RequestResult<GetAllFeaturesResponseDTO>.Success(mapper.Map<GetAllFeaturesResponseDTO>(res), "Feature already exists!") :
                    RequestResult<GetAllFeaturesResponseDTO>.Failure("Feature scope does not exist!");
        }
    }
}
