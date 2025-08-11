using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Feature.GetAllFeature.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Feature.GetAllFeature.Queries
{

    public record GetAllFeaturesQuery : IRequest<RequestResult<IEnumerable<GetAllFeaturesResponseDTO>>>;
    public class GetAllFeaturesQueryHandler : RequestHandlerBase<GetAllFeaturesQuery, IEnumerable<GetAllFeaturesResponseDTO>>
    {
        private readonly IGeneralRepository<Models.Feature> _featureRepository;

        public GetAllFeaturesQueryHandler(IGeneralRepository<Models.Feature> featureRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._featureRepository = featureRepository;
        }

        public async override Task<RequestResult<IEnumerable<GetAllFeaturesResponseDTO>>> Handle(GetAllFeaturesQuery request, CancellationToken cancellationToken)
        {
            var result = _featureRepository.Get(e => e.IsActive);

            var responseMapped = await mapper.ProjectTo<GetAllFeaturesResponseDTO>(result).ToListAsync();

            return  RequestResult<IEnumerable<GetAllFeaturesResponseDTO>>.Success(responseMapped);
        }
    }
}
