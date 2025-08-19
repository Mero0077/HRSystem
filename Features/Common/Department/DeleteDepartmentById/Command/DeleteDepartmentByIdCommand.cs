using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Department.DeleteDepartmentById.DTOs;
using HRSystem.Features.Common.Department.GetDepartmentById.DTOs;
using HRSystem.Features.Common.Department.GetDepartmentById.Queries;
using MediatR;

namespace HRSystem.Features.Common.Department.DeleteDepartmentById.Command
{
    public record DeleteDepartmentByIdCommand(Guid departmentId) : IRequest<RequestResult<DeleteDepartmentByIdQueryResponseDTO>>;
    public class DeleteDepartmentByIdCommandHandler : RequestHandlerBase<DeleteDepartmentByIdCommand, DeleteDepartmentByIdQueryResponseDTO>
    {
        private readonly IGeneralRepository<Models.Department> _departmentRepository;

        public DeleteDepartmentByIdCommandHandler(IGeneralRepository<Models.Department> departmentRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._departmentRepository = departmentRepository;
        }

        public override async Task<RequestResult<DeleteDepartmentByIdQueryResponseDTO>> Handle(DeleteDepartmentByIdCommand request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;

            var result = await mediator.Send(new GetDepartmentByIdQuery(new
                GetDepartmentByIdRequestDTO { DepartmentId=request.departmentId,OrganizationId = userStateOrganizationId }
                ));
            if (!result.IsSuccess)
                return RequestResult<DeleteDepartmentByIdQueryResponseDTO>.Failure(result.Message,result.ErrorCodes);

            await _departmentRepository.DeleteAsync(result.Data.Id, userStateOrganizationId);
            await _departmentRepository.SaveChangesAsync(cancellationToken);

            return RequestResult<DeleteDepartmentByIdQueryResponseDTO>.Success(mapper.Map<DeleteDepartmentByIdQueryResponseDTO>(result.Data));

        }
    }
}
