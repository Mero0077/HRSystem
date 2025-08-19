using AutoMapper.QueryableExtensions;
using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Department.GetDepartmentById.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Common.Department.GetDepartmentById.Queries
{
    public record GetDepartmentByIdQuery(GetDepartmentByIdRequestDTO GetDepartmentByIdRequestDTO) : IRequest<RequestResult<GetDepartmentByIdResponseDTO>>;
    public class GetDepartmentByIdQueryHandler : RequestHandlerBase<GetDepartmentByIdQuery, GetDepartmentByIdResponseDTO>
    {
        private readonly IGeneralRepository<Models.Department> _departmentRepository;

        public GetDepartmentByIdQueryHandler(IGeneralRepository<Models.Department> departmentRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._departmentRepository = departmentRepository;
        }

        public override async Task<RequestResult<GetDepartmentByIdResponseDTO>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            

            var department = await _departmentRepository
                .Get(e => e.Id == request.GetDepartmentByIdRequestDTO.DepartmentId, request.GetDepartmentByIdRequestDTO.OrganizationId)
                .ProjectTo<GetDepartmentByIdResponseDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (department == null)
                return RequestResult<GetDepartmentByIdResponseDTO>.Failure("Department is n't found",ErrorCodes.NotFound);

            if(request.GetDepartmentByIdRequestDTO.CompanyId.HasValue && request.GetDepartmentByIdRequestDTO.CompanyId != department.CompanyId)
                return RequestResult<GetDepartmentByIdResponseDTO>.Failure("Department does not belong to the specified Company.",
            ErrorCodes.NotFound);

            if(request.GetDepartmentByIdRequestDTO.BranchId.HasValue && request.GetDepartmentByIdRequestDTO.BranchId != department.BranchId)
                return RequestResult<GetDepartmentByIdResponseDTO>.Failure("Department does not belong to the specified Branch.",
            ErrorCodes.NotFound);


            return RequestResult<GetDepartmentByIdResponseDTO>.Success(department);



        }
    }
}
