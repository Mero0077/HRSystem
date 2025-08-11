using AutoMapper.QueryableExtensions;
using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Common.User.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Common.User.Queries
{

    public record GetUserByIdQuery(Guid userId) :IRequest<RequestResult<GetUserByIdResponseDTO>>;
    public class GetUserByIdQueryHandler : RequestHandlerBase<GetUserByIdQuery, GetUserByIdResponseDTO>
    {
        private readonly IGeneralRepository<Models.User> _userRepository;

        public GetUserByIdQueryHandler(IGeneralRepository<Models.User> userRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._userRepository = userRepository;
        }

        public override async Task<RequestResult<GetUserByIdResponseDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.Get(e=>e.Id==request.userId).ProjectTo<GetUserByIdResponseDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            return RequestResult<GetUserByIdResponseDTO>.Success(result);
        }
    }
}
