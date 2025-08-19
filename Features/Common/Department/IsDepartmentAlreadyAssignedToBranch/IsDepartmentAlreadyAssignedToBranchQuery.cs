using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Department.IsDepartmentAlreadyAssignedToBranch.DTO;
using MediatR;

namespace HRSystem.Features.Common.Department.IsDepartmentAlreadyAssignedToBranch
{
    public record IsDepartmentAlreadyAssignedToBranchQuery(IsDepartmentAlreadyAssignedToBranchRequestDTO IsDepartmentAlreadyAssignedToBranchRequestDTO) :IRequest<RequestResult<bool>>;
    public class IsDepartmentAlreadyAssignedToBranchQueryHandler : RequestHandlerBase<IsDepartmentAlreadyAssignedToBranchQuery, bool>
    {
        private IGeneralRepository<Models.Department> _DepartmentRepository;
        public IsDepartmentAlreadyAssignedToBranchQueryHandler(IGeneralRepository<Models.Department> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
              _DepartmentRepository = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(IsDepartmentAlreadyAssignedToBranchQuery request, CancellationToken cancellationToken)
        {
            var exists = await _DepartmentRepository.AnyAsync(e => e.Id == request.IsDepartmentAlreadyAssignedToBranchRequestDTO.DepartmentId && e.BranchId == request.IsDepartmentAlreadyAssignedToBranchRequestDTO.BranchId);
            return exists ?
                    RequestResult<bool>.Success(true, "department assigned") :
                    RequestResult<bool>.Failure("department not assigned");
        }
    }
}
