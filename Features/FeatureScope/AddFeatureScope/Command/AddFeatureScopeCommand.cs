using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.FeatureScope.AddFeatureScope.DTOs;
using HRSystem.Features.FeatureScope.AddFeatureScope.Query;
using MediatR;
using MediatR.Wrappers;

namespace HRSystem.Features.FeatureScope.AddFeatureScope.Command
{
    public record AddFeatureScopeCommand(AddFeatureScopeRequestDTO AddFeatureScopeRequestDTO):IRequest<RequestResult<AddFeatureScopeResponseDTO>>;
    public class AddFeatureScopeCommandHandler : RequestHandlerBase<AddFeatureScopeCommand, AddFeatureScopeResponseDTO>
    {
        private IGeneralRepository<HRSystem.Models.FeatureScope> _FeatureScopeepository;
        public AddFeatureScopeCommandHandler(IGeneralRepository<HRSystem.Models.FeatureScope> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _FeatureScopeepository = generalRepository;
        }

        public override async Task<RequestResult<AddFeatureScopeResponseDTO>> Handle(AddFeatureScopeCommand request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;
            request.AddFeatureScopeRequestDTO.OrganizationId = userStateOrganizationId;
            var exists = await mediator.Send(new IsFeatureScopeExistsQuery(request.AddFeatureScopeRequestDTO));
            if (exists.IsSuccess) return RequestResult<AddFeatureScopeResponseDTO>.Failure(exists.Message);

            var res= await _FeatureScopeepository.AddAsync(mapper.Map<HRSystem.Models.FeatureScope>(request.AddFeatureScopeRequestDTO));
                     await _FeatureScopeepository.SaveChangesAsync();

            return res != null ?
                        RequestResult<AddFeatureScopeResponseDTO>.Success(mapper.Map<AddFeatureScopeResponseDTO>(res)) :
                        RequestResult<AddFeatureScopeResponseDTO>.Failure("Could not add feature");
        }
    }
}
