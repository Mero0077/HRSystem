using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Auth.CreateAccount.DTO;
using HRSystem.Features.Common.User.Queries;
using HRSystem.Models;
using MediatR;
using MediatR.Wrappers;
using Microsoft.AspNetCore.Identity;

namespace HRSystem.Features.Auth.CreateAccount.Command
{
    public record CreateAccountCommand(CreateAccountDTO CreateAccountDTO):IRequest<RequestResult<CreateAccountResponseVM>>;
    public class CreateAccountCommandHandler : RequestHandlerBase<CreateAccountCommand, CreateAccountResponseVM>
    {
        private IGeneralRepository<HRSystem.Models.User> _userRepository;
        public CreateAccountCommandHandler(IGeneralRepository<HRSystem.Models.User> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _userRepository = generalRepository;
        }

        public async override Task<RequestResult<CreateAccountResponseVM>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var emailexists= await mediator.Send(new IsUserExistsByEmailQuery(request.CreateAccountDTO.Email));
            if(emailexists.IsSuccess) return RequestResult<CreateAccountResponseVM>.Failure("Email already exists",ErrorCodes.AlreadyExists);

            var user = mapper.Map<User>(request.CreateAccountDTO);
            user.HashedPassword=request.CreateAccountDTO.ConfirmedPassword;
            var hasher = new PasswordHasher<User>();
            string HashedPass = BCrypt.Net.BCrypt.HashPassword(user.HashedPassword);
            user.HashedPassword = HashedPass;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            var response = mapper.Map<CreateAccountResponseVM>(user);

            return RequestResult<CreateAccountResponseVM>.Success(response);
        }
    }
}
