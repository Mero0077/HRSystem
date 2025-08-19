using AutoMapper;
using HRSystem.Common.Views;
using HRSystem.Common;
using HRSystem.Features.Auth.Login.DTO;
using HRSystem.Features.Common.UserRole.GetUserWithRole.DTO;
using HRSystem.Features.Common.UserRole.GetUserWithRole;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Common.UserRole.Queries
{
    public record GetUserWithTheirRoles(LoginDTO GetUserWithRoleDTO) : IRequest<RequestResult<UserWithRoleResponseVM>>;
    public class GetUserWithTheirRolesHandler : RequestHandlerBase<GetUserWithTheirRoles, UserWithRoleResponseVM>
    {
        private IGeneralRepository<Models.User> _userRepository;
        public GetUserWithTheirRolesHandler(IGeneralRepository<Models.User> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _userRepository = generalRepository;
        }

        public override async Task<RequestResult<UserWithRoleResponseVM>> Handle(GetUserWithTheirRoles request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;


            var user = await _userRepository.Get(e => e.UserName == request.GetUserWithRoleDTO.UserName, userStateOrganizationId).Select
                 (e => new GetUserWithRoleDTO
                 {
                     UserId = e.Id,
                     UserName = e.UserName,
                     RoleIds = e.UserRole.Select(e => e.Id).ToList(),
                     Password = e.HashedPassword,
                 }).FirstOrDefaultAsync();

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.GetUserWithRoleDTO.Password, user.Password))
            {
                return RequestResult<UserWithRoleResponseVM>.Failure("Invalid username or password");
            }

            return RequestResult<UserWithRoleResponseVM>.Success(mapper.Map<UserWithRoleResponseVM>(user));
        }

    }
}
