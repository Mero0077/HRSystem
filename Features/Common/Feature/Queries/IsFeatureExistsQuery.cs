using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using MediatR;

namespace HRSystem.Features.Common.Feature.Queries
{
    public record IsFeatureExistsQuery(Guid featureId) : IRequest<RequestResult<bool>>;
    public class IsFeatureExistsQueryHandler : RequestHandlerBase<IsFeatureExistsQuery, bool>
    {
        private readonly IGeneralRepository<Models.Feature> _featureRepository;

        public IsFeatureExistsQueryHandler(IGeneralRepository<Models.Feature> featureRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._featureRepository = featureRepository;
        }

        public override async Task<RequestResult<bool>> Handle(IsFeatureExistsQuery request, CancellationToken cancellationToken)
        {
            var result = await _featureRepository.AnyAsync(e => e.Id == request.featureId, cancellationToken);
            return result ? RequestResult<bool>.Success(result) : RequestResult<bool>.Failure("Feature isnot Existed", ErrorCodes.NotFound);
        }
    }
}
