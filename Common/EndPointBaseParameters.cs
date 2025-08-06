using AutoMapper;
using FluentValidation;
using MediatR;

namespace HRSystem.Common
{
    public class EndPointBaseParameters<TRequest>
    {
        private readonly IMediator mediator;
        private IValidator<TRequest> validator { get; }
        private IMapper _mapper { get; }

        public IMediator Mediator { get { return mediator; } }
        public IValidator<TRequest> Validator => validator;
        public IMapper Mapper => _mapper;

        public EndPointBaseParameters(IMediator mediator, IValidator<TRequest> validator,IMapper mapper)
        {
            this.mediator = mediator;
            this.validator = validator;
            this._mapper = mapper;
        }

    }
}
