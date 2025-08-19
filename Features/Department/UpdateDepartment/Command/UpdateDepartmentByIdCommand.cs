using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Branch.IsBranchExistsQuery.Queries;
using HRSystem.Features.Common.Department;
using HRSystem.Features.Common.Department.GetDepartmentById.DTOs;
using HRSystem.Features.Common.Department.GetDepartmentById.Queries;
using HRSystem.Features.Department.UpdateDepartment.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HRSystem.Features.Department.UpdateDepartment.Command
{
    public record UpdateDepartmentByIdCommand(Guid departmentId,UpdateDepartmentByIdRequestDTO UpdateDepartmentByIdRequestDTO) : IRequest<RequestResult<UpdateDepartmentByIdResponseDTO>>;

    public class UpdateDepartmentByIdCommandHandler : RequestHandlerBase<UpdateDepartmentByIdCommand, UpdateDepartmentByIdResponseDTO>
    {
        private readonly IGeneralRepository<Models.Department> _departmentRepository;

        public UpdateDepartmentByIdCommandHandler(IGeneralRepository<Models.Department> departmentRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._departmentRepository = departmentRepository;
        }

        public override async Task<RequestResult<UpdateDepartmentByIdResponseDTO>> Handle(UpdateDepartmentByIdCommand request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;

            var result = await _departmentRepository.GetOneByIdAsync(request.departmentId, userStateOrganizationId);
            if (result==null)
                return RequestResult<UpdateDepartmentByIdResponseDTO>.Failure("Department Not Found",ErrorCodes.NotFound);

            if (!string.IsNullOrWhiteSpace(request.UpdateDepartmentByIdRequestDTO.Name))
            {
                var departmentNameResult = await mediator.Send(new IsDepartmentExistsQuery(request.UpdateDepartmentByIdRequestDTO.Name));
                if (!departmentNameResult.IsSuccess)
                {
                    result.Name = request.UpdateDepartmentByIdRequestDTO.Name;
                }
            }

            if (!string.IsNullOrWhiteSpace(request.UpdateDepartmentByIdRequestDTO.Description))
            {
                    result.Description = request.UpdateDepartmentByIdRequestDTO.Description;
            }

            if (request.UpdateDepartmentByIdRequestDTO.NumOfEmployees !=null)
            {
                    result.NumOfEmployees = (int)request.UpdateDepartmentByIdRequestDTO.NumOfEmployees;
            }
            await _departmentRepository.SaveChangesAsync(cancellationToken);
            return RequestResult<UpdateDepartmentByIdResponseDTO>.Success(mapper.Map<UpdateDepartmentByIdResponseDTO>(result));

        }
    }
}
