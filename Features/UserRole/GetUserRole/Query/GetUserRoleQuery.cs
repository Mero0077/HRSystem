using HRSystem.Common;
using HRSystem.Common.Views;
using MediatR;
using MediatR.Wrappers;

namespace HRSystem.Features.UserRole.GetUserRole.Query
{
    public record GetUserRoleQuery(Guid UserId):IRequest<RequestResult<Guid>>;
    public class GetUserRoleQueryHandler : RequestHandlerBase<GetUserRoleQuery, Guid>
    {
        private IGeneralRepository<HRSystem.Models.UserRole> _repository;
        public GetUserRoleQueryHandler(IGeneralRepository<HRSystem.Models.UserRole> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _repository = generalRepository;
        }

        public override async Task<RequestResult<Guid>> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
          var UserRole= await _repository.GetOneWithTrackingAsync(e=>e.UserId==request.UserId);
            return UserRole != null ?
                      RequestResult<Guid>.Success(UserRole.RoleId) :
                      RequestResult<Guid>.Failure("no role");
        }
    }
}
