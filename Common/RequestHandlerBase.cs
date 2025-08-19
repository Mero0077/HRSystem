using AutoMapper;
using Azure;
using HRSystem.Common.Views;
using MediatR;

namespace HRSystem.Common
{
    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, RequestResult<TResponse>> where TRequest : IRequest<RequestResult<TResponse>>
    {
        protected IMediator mediator;
        protected IMapper mapper;
        protected UserStateViewModel userState;
        public RequestHandlerBase(RequestHandlerBaseParameters parameters)
        {
            mediator = parameters.Mediator;
            mapper = parameters.Mapper;
            userState = parameters.UserState;
        }

        public abstract Task<RequestResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}

