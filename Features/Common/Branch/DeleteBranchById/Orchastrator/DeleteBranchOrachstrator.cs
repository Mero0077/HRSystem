using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Branch.Delete_Branch.Command;
using HRSystem.Features.Branch.Delete_Branch.DTOs;
using HRSystem.Features.Common.Branch.DeleteBranchById.DTOs;
using HRSystem.Features.Common.Branch.GetBranchByIdQuery.DTOs;
using HRSystem.Features.Common.Branch.GetBranchByIdQuery.Queries;
using HRSystem.Features.Common.Department.DeleteDepartmentById.Command;
using MediatR;

namespace HRSystem.Features.Branch.Delete_Branch.Orchastrator
{
    public record DeleteBranchOrachstrator(Guid branchId) : IRequest<RequestResult<DeleteBranchResponseOrachstratorDTO>>;
    public class DeleteBranchOrachstratorHandler : RequestHandlerBase<DeleteBranchOrachstrator, DeleteBranchResponseOrachstratorDTO>
    {
    

        public DeleteBranchOrachstratorHandler(RequestHandlerBaseParameters parameters) : base(parameters)
        {
   
        }

        public override async Task<RequestResult<DeleteBranchResponseOrachstratorDTO>> Handle(DeleteBranchOrachstrator request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new DeleteBranchByIdCommand(request.branchId));
            if (!result.IsSuccess)
                return RequestResult<DeleteBranchResponseOrachstratorDTO>.Failure(result.Message,result.ErrorCodes);
            if (result.Data.DepartmentIds.Any())
            {
                foreach(var depId in result.Data.DepartmentIds)
                {
                    await mediator.Send(new DeleteDepartmentByIdCommand(depId));
                }
            }
            return RequestResult<DeleteBranchResponseOrachstratorDTO>.Success(new DeleteBranchResponseOrachstratorDTO
            {
                BranchId = result.Data.Id,
                DeletedDepartmentIds = result.Data.DepartmentIds.ToList(),
            });
        }
    }
}
