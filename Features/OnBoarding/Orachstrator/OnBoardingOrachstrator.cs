//using HRSystem.Common;
//using HRSystem.Common.Views;
//using HRSystem.Features.Company.AddCompany.Command;
//using HRSystem.Features.Company.AddCompany.DTOs;
//using HRSystem.Features.Department.AddDepartment.Command;
//using HRSystem.Features.Department.AddDepartment.DTOs;
//using HRSystem.Features.OnBoarding.DTOs;
//using HRSystem.Features.Organization.AddOrganization.Commands;
//using HRSystem.Features.Organization.AddOrganization.DTOs;
//using MediatR;

//namespace HRSystem.Features.OnBoarding.Orachstrator
//{
//    public record OnBoardingOrachstrator(OnBoardingResquestOrachstrator OnBoardingResquestOrachstrator) : IRequest<RequestResult<OnBoardingResponseOrachstrator>>;


//    public class OnBoardingOrachstratorHandler : RequestHandlerBase<OnBoardingOrachstrator, OnBoardingResponseOrachstrator>
//    {
//        public OnBoardingOrachstratorHandler(RequestHandlerBaseParameters parameters) : base(parameters)
//        {
//        }

//        public override async Task<RequestResult<OnBoardingResponseOrachstrator>> Handle(OnBoardingOrachstrator request, CancellationToken cancellationToken)
//        {
//            var organization = await mediator.Send(new AddOrganizationCommand(mapper.Map<AddOrganizationDTO>(request.OnBoardingResquestOrachstrator.organizationRequestDTO)));

//            var company = await mediator.Send(new AddCompanyCommand(mapper.Map<AddCompanyDTO>(request.OnBoardingResquestOrachstrator.companyRequestDTO)));

//            var branch = await mediator.Send(new AddDepartmentCommand(mapper.Map<AddDepartmentRequestDTO>(request.OnBoardingResquestOrachstrator.branchRequestDTO)));

//            var department = await mediator.Send(new AddDepartmentCommand(mapper.Map<AddDepartmentRequestDTO>(request.OnBoardingResquestOrachstrator.departmentRequestDTO)));


//        }
//    }
//}
