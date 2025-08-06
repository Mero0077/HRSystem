using FluentValidation;
using MediatR;

namespace HRSystem.Common
{
    public class EndPointBaseParameters<TRequest>
    {
        private readonly IMediator mediator;
        private IValidator<TRequest> validator { get; }

        public IMediator Mediator { get { return mediator; } }
        public IValidator<TRequest> Validator => validator;

        public EndPointBaseParameters(IMediator mediator, IValidator<TRequest> validator)
        {
            this.mediator = mediator;
            this.validator = validator;
        }

    }
}
