using HRSystem.Common;
using HRSystem.Common.Views;
using MediatR;

namespace HRSystem.Features.Common.Department
{
    public record IsDepartmentExistsQuery(string Name):IRequest<RequestResult<bool>>;
    public class IsDepartmentExistsQueryHandler : RequestHandlerBase<IsDepartmentExistsQuery, bool>
    {
        private IGeneralRepository<Models.Department> _departmentRepo;
        public IsDepartmentExistsQueryHandler(IGeneralRepository<Models.Department> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _departmentRepo = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(IsDepartmentExistsQuery request, CancellationToken cancellationToken)
        {
            var exists = await _departmentRepo.GetOneWithTrackingAsync(e => e.Name == request.Name);
            return exists != null ?
                    RequestResult<bool>.Success(true, "department exists") :
                    RequestResult<bool>.Failure( "department does not exist");
        }
    }
}
