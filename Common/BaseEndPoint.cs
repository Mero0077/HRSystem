using AutoMapper;
using FluentValidation;
using HRSystem.Common.Views;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Common
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BaseEndPoint<TRequest, TResult> : ControllerBase
    {
        protected IMediator mediator;
        protected IValidator<TRequest> validator;
        protected IMapper mapper;
        public BaseEndPoint(EndPointBaseParameters<TRequest> parameters)
        {
            mediator = parameters.Mediator;
            validator = parameters.Validator;
            mapper = parameters.Mapper;
        }

        protected EndPointResponse<TResult> ValidateRequest(TRequest request)

        {
            var validateResult = validator.Validate(request);
            if(!validateResult.IsValid)
            {
                var errorMessage = string.Join(", ", validateResult.Errors.Select(e => e.ErrorMessage));
                return EndPointResponse<TResult>.Failure(errorMessage);
            }
            return EndPointResponse<TResult>.Success(default,"Validation Successful");
        }
    }
}
