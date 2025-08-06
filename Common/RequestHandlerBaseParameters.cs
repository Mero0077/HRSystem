using AutoMapper;
using FluentValidation;
using MediatR;

namespace HRSystem.Common
{
    public class RequestHandlerBaseParameters
    {
        private readonly IMediator _mediator;
        private IMapper _mapper { get; }

        public IMediator Mediator { get { return _mediator; } }
        public IMapper Mapper =>_mapper;

        public RequestHandlerBaseParameters(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
