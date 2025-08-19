using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Branch.GetBranchByIdQuery.DTOs;
using HRSystem.Features.Common.Branch.GetBranchByIdQuery.Queries;
using HRSystem.Features.Common.Company.GetCompnayByIdQuery.DTOs;
using HRSystem.Features.Common.Company.GetCompnayByIdQuery.Queries;
using HRSystem.Features.Common.Department.GetDepartmentById.DTOs;
using HRSystem.Features.Common.Department.GetDepartmentById.Queries;
using HRSystem.Features.Common.Organization.GetOrganizationById.DTOs;
using HRSystem.Features.Common.Organization.GetOrganizationById.Queries;
using HRSystem.Features.Common.Organization.GetOrganizationWithChildren.DTOs;
using HRSystem.Features.Common.Organization.GetOrganizationWithChildren.Queries;
using HRSystem.Features.RoleScope.AssignRoleScope.DTOs;
using HRSystem.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HRSystem.Features.RoleScope.AssignRoleScope.Commands
{
    public record AssignRoleScopeCommand(AssignRoleScopeRequestDTO AssignRoleScopeRequestDTO) : IRequest<RequestResult<AssignRoleScopeResponseDTO>>;
    public class AssignRoleScopeCommandHandler : RequestHandlerBase<AssignRoleScopeCommand, AssignRoleScopeResponseDTO>
    {
        private readonly HashSet<string> _existingScopeKeys;
        private readonly IGeneralRepository<Models.RoleScope> _roleScopeRepository;

        public AssignRoleScopeCommandHandler(IGeneralRepository<Models.RoleScope>roleScopeRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _existingScopeKeys = new HashSet<string>();
            this._roleScopeRepository = roleScopeRepository;
        }

        public override async Task<RequestResult<AssignRoleScopeResponseDTO>> Handle(AssignRoleScopeCommand request, CancellationToken cancellationToken)
        {
            var roleScopeList = new List<Models.RoleScope>();
            var roleId = request.AssignRoleScopeRequestDTO.RoleId;
            var targetId = request.AssignRoleScopeRequestDTO.TargetId;
            var nodeLevel = request.AssignRoleScopeRequestDTO.NodeLevel;

            var userStateOrganizationId = userState.OrganizationId;


            var existingScopes = await _roleScopeRepository.Get(e => e.RoleId == roleId && e.IsActive, userStateOrganizationId)
               .ToListAsync(cancellationToken);
            foreach (var scope in existingScopes)
            {
                _existingScopeKeys.Add(GenerateScopeKey(roleId, scope.OrganizationId, scope.CompanyId, scope.BranchId, scope.DepartmentId));
            }

            switch (request.AssignRoleScopeRequestDTO.NodeLevel)
            {
                case NodeLevel.Organization:
                    var organizationResult = await mediator.Send(new 
                        GetOrganizationWithChildrenQuery(new 
                        GetOrganizationWithChildrenRequestDTO { OrganizationId=targetId})
                        ,cancellationToken);
                    if (!organizationResult.IsSuccess)
                        return RequestResult<AssignRoleScopeResponseDTO>.Failure(organizationResult.Message, organizationResult.ErrorCodes);
                    var orgHierarchy = mapper.Map<OrganizationHierarchyResponseDTO>(organizationResult.Data);
                    await BuildChildrenHierarchyAsync(orgHierarchy, userStateOrganizationId, cancellationToken);
                    AddOrganizationCascade(roleScopeList, request.AssignRoleScopeRequestDTO.RoleId, orgHierarchy);
                    break;

                case NodeLevel.Company:
                    var company = await mediator.Send(new GetCompanyByIdQuery(new GetCompanyByIdQueryRequestDTO { CompanyId = targetId,OrganizationId= userStateOrganizationId }), cancellationToken); 
                    if (!company.IsSuccess)
                        return RequestResult<AssignRoleScopeResponseDTO>.Failure("No Company Found", ErrorCodes.NotFound);
                    var companyHierarchy = mapper.Map<CompanyHierarchyResponseDTO>(company.Data);
                    await BuildChildrenHierarchyAsync(companyHierarchy, cancellationToken);
                    AddCompanyCascade(roleScopeList, request.AssignRoleScopeRequestDTO.RoleId, companyHierarchy);
                    break;

                case NodeLevel.Branch:
                    var branch = await mediator.Send(new GetBranchByIdQuery(new GetBranchByIdQueryRequestDTO { BranchId = targetId,OrganizationId = userStateOrganizationId }), cancellationToken); 
                    if (!branch.IsSuccess)
                        return RequestResult<AssignRoleScopeResponseDTO>.Failure("No Branch Found", ErrorCodes.NotFound);
                    var branchHierarchy = mapper.Map<BranchHierarchyResponseDTO>(branch.Data);
                    await BuildChildrenHierarchyAsync(branchHierarchy, cancellationToken);
                    AddBranchCascade(roleScopeList, request.AssignRoleScopeRequestDTO.RoleId, branchHierarchy);
                    break;

                case NodeLevel.Department:
                    var department = await mediator.Send(new GetDepartmentByIdQuery(new GetDepartmentByIdRequestDTO { DepartmentId = targetId }), cancellationToken);
                    if (!department.IsSuccess)
                        return RequestResult<AssignRoleScopeResponseDTO>.Failure("No Department Found", ErrorCodes.NotFound);
                    var departmentHierarchy = mapper.Map<DepartmentHierarchyResponseDTO>(department);
                    AddDepartmentCascade(roleScopeList, request.AssignRoleScopeRequestDTO.RoleId, departmentHierarchy);
                    break;


             }
            if (roleScopeList.Any())
            {
                await _roleScopeRepository.AddAsyncRange(roleScopeList);
                await _roleScopeRepository.SaveChangesAsync(cancellationToken);
            }
            return RequestResult<AssignRoleScopeResponseDTO>.Success(new AssignRoleScopeResponseDTO
            {
                RoleId = roleId,
                NodeLevel = nodeLevel,
                AssignedToId = targetId,
            });
        }
        private async Task BuildChildrenHierarchyAsync(OrganizationHierarchyResponseDTO organizationHierarchyResponseDTO,Guid userStateOrganizationId, CancellationToken cancellationToken)
        {

            foreach (var company in organizationHierarchyResponseDTO.Companies.ToList())
            {
                var companyResult = await mediator.Send(new GetCompanyByIdQuery(new
                    GetCompanyByIdQueryRequestDTO
                { CompanyId = company.Id, OrganizationId = userStateOrganizationId }
                    ));
                if (companyResult.IsSuccess)
                {
                    var companyHierarchy = mapper.Map<CompanyHierarchyResponseDTO>(companyResult.Data);
                    await BuildChildrenHierarchyAsync(companyHierarchy, cancellationToken);
                    var idx = organizationHierarchyResponseDTO.Companies.FindIndex(c => c.Id == company.Id);
                    if (idx >= 0)
                        organizationHierarchyResponseDTO.Companies[idx] = companyHierarchy;
                }

            }
        }
        private async Task BuildChildrenHierarchyAsync(CompanyHierarchyResponseDTO companyHierarchyResponseDTO, CancellationToken cancellationToken)
        {

            foreach (var branchId in companyHierarchyResponseDTO.BranchIds ?? new List<Guid>())
            {
                var branchResult = await mediator.Send(new GetBranchByIdQuery(new
                    GetBranchByIdQueryRequestDTO
                { BranchId=branchId,CompanyId= companyHierarchyResponseDTO.Id,OrganizationId=companyHierarchyResponseDTO.OrganizationId }
                    ));
                if (branchResult.IsSuccess)
                {
                    var branchHierarchy = mapper.Map<BranchHierarchyResponseDTO>(branchResult.Data);
                    await BuildChildrenHierarchyAsync(branchHierarchy, cancellationToken);
                    var idx = companyHierarchyResponseDTO.Branches.FindIndex(b => b.Id == branchHierarchy.Id);
                    if (idx >= 0)
                        companyHierarchyResponseDTO.Branches[idx] = branchHierarchy;
                    else
                        companyHierarchyResponseDTO.Branches.Add(branchHierarchy);
                }

            }
        }
        private async Task BuildChildrenHierarchyAsync(BranchHierarchyResponseDTO branchHierarchyResponseDTO, CancellationToken cancellationToken)
        {

            foreach (var departmentId in branchHierarchyResponseDTO.DepartmentIds ?? new List<Guid>())
            {
                var departmentResult = await mediator.Send(new GetDepartmentByIdQuery(new
                    GetDepartmentByIdRequestDTO
                { DepartmentId= departmentId, BranchId = branchHierarchyResponseDTO.Id, CompanyId = branchHierarchyResponseDTO.CompanyId, OrganizationId = branchHierarchyResponseDTO.OrganizationId }
                    ));
                if (departmentResult.IsSuccess)
                {
                    var departmentHierarchy = mapper.Map<DepartmentHierarchyResponseDTO>(departmentResult.Data);
                    var idx = branchHierarchyResponseDTO.Departments.FindIndex(d => d.Id == departmentHierarchy.Id);
                    if (idx >= 0)
                        branchHierarchyResponseDTO.Departments[idx] = departmentHierarchy;
                    else
                        branchHierarchyResponseDTO.Departments.Add(departmentHierarchy);
                }

            }
        }


        private void AddOrganizationCascade(List<Models.RoleScope> roleScopes, Guid roleId, OrganizationHierarchyResponseDTO organization)
        {
            //AddRoleScopeIfNotExists(roleScopes, roleId, organization.Id, Guid.Empty, Guid.Empty, Guid.Empty);
            foreach (var company in organization.Companies)
                AddCompanyCascade(roleScopes, roleId, company);
        }

        private void AddCompanyCascade(List<Models.RoleScope> roleScopes, Guid roleId, CompanyHierarchyResponseDTO company)
        {
            //AddRoleScopeIfNotExists(roleScopes, roleId, company.OrganizationId, company.Id, Guid.Empty, Guid.Empty);
            foreach (var branch in company.Branches)
                 AddBranchCascade(roleScopes, roleId, branch);

        }

        private void AddBranchCascade(List<Models.RoleScope> roleScopes, Guid roleId, BranchHierarchyResponseDTO branch)
        {
            //AddRoleScopeIfNotExists(roleScopes, roleId, branch.OrganizationId, branch.CompanyId, branch.Id, Guid.Empty);
            foreach (var department in branch.Departments)
                 AddDepartmentCascade(roleScopes, roleId, department);
        }
        private void AddDepartmentCascade(List<Models.RoleScope> roleScopes, Guid roleId, DepartmentHierarchyResponseDTO department)
        {
            AddRoleScopeIfNotExists(roleScopes, roleId, department.OrganizationId, department.CompanyId, department.BranchId, department.Id);
        }
        private string GenerateScopeKey(Guid roleId, Guid organizationId, Guid companyId, Guid branchId, Guid departmentId)
        {
            return $"{roleId}|{organizationId}|{companyId}|{branchId}|{departmentId}";
        }
        private bool AddRoleScopeIfNotExists(List<Models.RoleScope> roleScopes, Guid roleId, Guid organiozationId, Guid companyId, Guid branchId, Guid departmentId)
        {
            var scopeKey = GenerateScopeKey(roleId, organiozationId, companyId, branchId, departmentId);
            if (!_existingScopeKeys.Contains(scopeKey))
            {
                _existingScopeKeys.Add(scopeKey);
                roleScopes.Add(new Models.RoleScope
                {
                    Id = Guid.NewGuid(),
                    OrganizationId = organiozationId,
                    CompanyId = companyId,
                    BranchId = branchId,
                    DepartmentId = departmentId,
                    IsActive = true,
                    RoleId = roleId
                });
                return true;
            }
            return false ;
        }
    }
}
