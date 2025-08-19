using AutoMapper;
using FluentValidation;
using HRSystem.Common.Views;
using MediatR;

namespace HRSystem.Common
{
    public class RequestHandlerBaseParameters
    {
        private readonly IMediator _mediator;
        private IMapper _mapper { get; }

        private UserStateViewModel _userState;
        public IMediator Mediator { get { return _mediator; } }
        public IMapper Mapper =>_mapper;

        public UserStateViewModel UserState => _userState;

        public RequestHandlerBaseParameters(IMediator mediator,IMapper mapper,UserStateViewModel userstate)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userState = userstate;
        }
    }
}
