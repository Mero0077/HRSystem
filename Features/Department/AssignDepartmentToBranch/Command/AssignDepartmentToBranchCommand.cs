using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Department.IsDepartmentAlreadyAssignedToBranch;
using HRSystem.Features.Common.Department.IsDepartmentAlreadyAssignedToBranch.DTO;
using HRSystem.Features.Company.AssignCompanyToOrganization.DTOs;
using HRSystem.Features.Department.AssignDepartmentToBranch.DTOs;
using MediatR;
using MediatR.Wrappers;

namespace HRSystem.Features.Department.AssignDepartmentToBranch.Command
{
    public record AssignDepartmentToBranchCommand(AssignDepartmentToBranchRequestDTO AssignDepartmentToBranchRequestDTO):IRequest<RequestResult<AssignDepartmentToBranchResponseDTO>>;
    public class AssignDepartmentToBranchCommandHandler : RequestHandlerBase<AssignDepartmentToBranchCommand, AssignDepartmentToBranchResponseDTO>
    {
        private IGeneralRepository<Models.Department> _DepartmentRepository;
        public AssignDepartmentToBranchCommandHandler(IGeneralRepository<Models.Department> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _DepartmentRepository = generalRepository;
        }

        public override async Task<RequestResult<AssignDepartmentToBranchResponseDTO>> Handle(AssignDepartmentToBranchCommand request, CancellationToken cancellationToken)
        {
            var assigned = await mediator.Send(new IsDepartmentAlreadyAssignedToBranchQuery(mapper.Map<IsDepartmentAlreadyAssignedToBranchRequestDTO>(request)));
            if(assigned.IsSuccess) return RequestResult<AssignDepartmentToBranchResponseDTO>.Failure(assigned.Message);

            var department= await _DepartmentRepository.GetOneWithTrackingAsync(e=>e.Id==request.AssignDepartmentToBranchRequestDTO.DepartmentId&& e.BranchId==request.AssignDepartmentToBranchRequestDTO.BranchId);
            department.BranchId=request.AssignDepartmentToBranchRequestDTO.BranchId;
            await _DepartmentRepository.SaveChangesAsync();

            return RequestResult<AssignDepartmentToBranchResponseDTO>.Success(mapper.Map<AssignDepartmentToBranchResponseDTO>(department));
        }
    }
}
