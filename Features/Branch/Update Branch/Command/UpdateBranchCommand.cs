using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Branch.Update_Branch.DTOs;
using HRSystem.Features.Common.Branch.GetBranchByIdQuery.DTOs;
using HRSystem.Features.Common.Branch.GetBranchByIdQuery.Queries;
using HRSystem.Models;
using MediatR;

namespace HRSystem.Features.Branch.Update_Branch.Command
{
    public record UpdateBranchCommand(Guid BranchId,UpdateBranchRequestDTO UpdateBranchRequestDTO) : IRequest<RequestResult<UpdateBranchResponseDTO>>;

    public class UpdateBranchCommandHandler : RequestHandlerBase<UpdateBranchCommand, UpdateBranchResponseDTO>
    {
        private readonly IGeneralRepository<Models.Branch> _branchRepository;

        public UpdateBranchCommandHandler(IGeneralRepository<Models.Branch> branchRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._branchRepository = branchRepository;
        }

        public override async Task<RequestResult<UpdateBranchResponseDTO>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;
            var result = await _branchRepository.GetOneByIdAsync(request.BranchId, userStateOrganizationId);
            if (result == null)
                return RequestResult<UpdateBranchResponseDTO>.Failure("Branch not found", ErrorCodes.NotFound);

            if (!string.IsNullOrWhiteSpace(request.UpdateBranchRequestDTO.Name))
                result.Name = request.UpdateBranchRequestDTO.Name;

            if (!string.IsNullOrWhiteSpace(request.UpdateBranchRequestDTO.City))
                result.City = request.UpdateBranchRequestDTO.City;


            await _branchRepository.SaveChangesAsync(cancellationToken);

            var response = new UpdateBranchResponseDTO
            {
                Id = result.Id,
                Name = result.Name,
                City = result.City,
                CompanyId = result.CompanyId,
                Description = result.Description,
                Location = result.Location,
                TimeZone = result.TimeZone
            };

            return RequestResult<UpdateBranchResponseDTO>.Success(response, "Branch updated successfully");

        }
    }
}
