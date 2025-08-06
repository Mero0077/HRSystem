using Azure;
using MediatR;

namespace HRSystem.Common
{
    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected IMediator mediator;
        public RequestHandlerBase(RequestHandlerBaseParameters parameters)
        {
            mediator=parameters.Mediator;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
