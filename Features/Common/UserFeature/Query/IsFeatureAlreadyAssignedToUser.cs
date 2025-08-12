using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.UserFeature.AssignFeatureToUser.DTO;
using MediatR;

namespace HRSystem.Features.Common.UserFeature.Query
{
    public record IsFeatureAlreadyAssignedToUser(AssignFeatureToUserRequestDTO AssignFeatureToUserRequestDTO):IRequest<RequestResult<bool>>;
    public class IsFeatureAlreadyAssignedToUserHandler : RequestHandlerBase<IsFeatureAlreadyAssignedToUser, bool>
    {
        private IGeneralRepository<HRSystem.Models.UserFeature> _userFeatureRepository;
        public IsFeatureAlreadyAssignedToUserHandler(IGeneralRepository<HRSystem.Models.UserFeature> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _userFeatureRepository = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(IsFeatureAlreadyAssignedToUser request, CancellationToken cancellationToken)
        {
            var res = await _userFeatureRepository.GetOneWithTrackingAsync(e => e.UserId == request.AssignFeatureToUserRequestDTO.UserId && e.FeatureId == request.AssignFeatureToUserRequestDTO.FeatureId);
            return res != null ?
                    RequestResult<bool>.Success(true) :
                    RequestResult<bool>.Failure("Not assigned");
        }
    }
}
