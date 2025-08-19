using AutoMapper;
using HRSystem.Common.Views;
using HRSystem.Common;
using HRSystem.Features.Auth.Login.DTO;
using HRSystem.Features.Common.UserRole.GetUserWithRole.DTO;
using HRSystem.Features.Common.UserRole.GetUserWithRole;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Common.UserRole.GetUserWithRole.Queries
{
    public record GetUserWithTheirRoles(LoginDTO GetUserWithRoleDTO) : IRequest<RequestResult<UserWithRoleResponseDTO>>;
    public class GetUserWithTheirRolesHandler : RequestHandlerBase<GetUserWithTheirRoles, UserWithRoleResponseDTO>
    {
        private IGeneralRepository<Models.User> _userRepository;
        public GetUserWithTheirRolesHandler(IGeneralRepository<Models.User> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _userRepository = generalRepository;
        }

        public override async Task<RequestResult<UserWithRoleResponseDTO>> Handle(GetUserWithTheirRoles request, CancellationToken cancellationToken)
        {


            var user = await _userRepository.Get(e => e.UserName == request.GetUserWithRoleDTO.UserName).Select
                 (e => new GetUserWithRoleDTO
                 {
                     UserId = e.Id,
                     UserName = e.UserName,
                     RoleIds = e.UserRole.Select(e => e.Id).ToList(),
                     Password = e.HashedPassword,
                     OrganizationId = e.OrganizationId,
                 }).FirstOrDefaultAsync();

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.GetUserWithRoleDTO.Password, user.Password))
            {
                return RequestResult<UserWithRoleResponseDTO>.Failure("Invalid username or password");
            }

            return RequestResult<UserWithRoleResponseDTO>.Success(mapper.Map<UserWithRoleResponseDTO>(user));
        }

    }
}
