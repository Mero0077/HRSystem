using AutoMapper.QueryableExtensions;
using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Common.User.GetUserById.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Common.User.GetUserById
{

    public record GetUserByIdQuery(string userName) :IRequest<RequestResult<GetUserByIdResponseDTO>>;
    public class GetUserByIdQueryHandler : RequestHandlerBase<GetUserByIdQuery, GetUserByIdResponseDTO>
    {
        private readonly IGeneralRepository<Models.User> _userRepository;

        public GetUserByIdQueryHandler(IGeneralRepository<Models.User> userRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _userRepository = userRepository;
        }

        public override async Task<RequestResult<GetUserByIdResponseDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.Get(e=>e.UserName==request.userName).ProjectTo<GetUserByIdResponseDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            return RequestResult<GetUserByIdResponseDTO>.Success(result);
        }
    }
}
