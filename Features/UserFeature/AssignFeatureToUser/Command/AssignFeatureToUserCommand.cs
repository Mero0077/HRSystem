using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Feature.Queries;
using HRSystem.Features.Common.User.Queries;
using HRSystem.Features.Common.UserFeature.Query;
using HRSystem.Features.RoleFeature.AssignFeatureToRole.DTOs;
using HRSystem.Features.UserFeature.AssignFeatureToUser.DTO;
using MediatR;

namespace HRSystem.Features.UserFeature.AssignFeatureToUser.Command
{
    public record AssignFeatureToUserCommand(AssignFeatureToUserRequestDTO assignFeatureToUserRequestDTO):IRequest<RequestResult<AssignFeatureToUserResponseDTO>>;
    public class AssignFeatureToUserCommandHandler : RequestHandlerBase<AssignFeatureToUserCommand, AssignFeatureToUserResponseDTO>
    {
        private IGeneralRepository<HRSystem.Models.UserFeature> _UserFeatureRepository;
        public AssignFeatureToUserCommandHandler(IGeneralRepository<HRSystem.Models.UserFeature> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _UserFeatureRepository = generalRepository;
        }

        public override async Task<RequestResult<AssignFeatureToUserResponseDTO>> Handle(AssignFeatureToUserCommand request, CancellationToken cancellationToken)
        {
            var feature = await mediator.Send(new IsFeatureExistsQuery(request.assignFeatureToUserRequestDTO.FeatureId));
            if(!feature.IsSuccess) return RequestResult<AssignFeatureToUserResponseDTO>.Failure(feature.Message);

            var User = await mediator.Send(new IsUserExistsQuery(request.assignFeatureToUserRequestDTO.UserId));
            if(!User.IsSuccess) return RequestResult<AssignFeatureToUserResponseDTO>.Failure(User.Message);

            var FeatureAssigned= await mediator.Send(new IsFeatureAlreadyAssignedToUser(request.assignFeatureToUserRequestDTO));
            if(FeatureAssigned.IsSuccess) return RequestResult<AssignFeatureToUserResponseDTO>.Failure(FeatureAssigned.Message);

            var res= await _UserFeatureRepository.AddAsync(mapper.Map<HRSystem.Models.UserFeature>(request.assignFeatureToUserRequestDTO));
                     await _UserFeatureRepository.SaveChangesAsync();

            return RequestResult<AssignFeatureToUserResponseDTO>.Success(mapper.Map<AssignFeatureToUserResponseDTO>(res));
        }
    }
}
