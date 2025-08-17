using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Department;
using HRSystem.Features.Department.AddDepartment.DTOs;
using HRSystem.Features.Department.AddDepartment.VMs;
using MediatR;

namespace HRSystem.Features.Department.AddDepartment.Command
{
    public record AddDepartmentCommand(AddDepartmentRequestDTO AddDepartmentRequestDTO):IRequest<RequestResult<AddDepartmentResponseDTO>>;
    public class AddDepartmentCommandHandler : RequestHandlerBase<AddDepartmentCommand, AddDepartmentResponseDTO>
    {
        private IGeneralRepository<Models.Department> _DepartmentRepo;
        public AddDepartmentCommandHandler(IGeneralRepository<Models.Department> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _DepartmentRepo = generalRepository;
        }

        public override async Task<RequestResult<AddDepartmentResponseDTO>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var exists = await mediator.Send(new IsDepartmentExistsQuery(request.AddDepartmentRequestDTO.Name));
            if (exists != null) return RequestResult< AddDepartmentResponseDTO>.Failure(exists.Message);

            var res= await _DepartmentRepo.AddAsync(mapper.Map<Models.Department>(request.AddDepartmentRequestDTO));
            return res != null ?
                     RequestResult<AddDepartmentResponseDTO>.Success(mapper.Map<AddDepartmentResponseDTO>(res), "department added") :
                     RequestResult<AddDepartmentResponseDTO>.Failure("could not add department");
        }
    }
}
