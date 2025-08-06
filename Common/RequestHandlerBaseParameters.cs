using FluentValidation;
using MediatR;

namespace HRSystem.Common
{
    public class RequestHandlerBaseParameters
    {
        private readonly IMediator _mediator;
        public IMediator Mediator { get { return _mediator; } }
        public RequestHandlerBaseParameters(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
