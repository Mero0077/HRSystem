using AutoMapper;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Common.FeatureEndPoint.DTO;
using HRSystem.Features.Common.FeatureEndPoint.GetEndpointFeatures.Query;
using HRSystem.Features.EndPoints;
using HRSystem.Features.EndPoints.GetEndPoint.DTO;
using HRSystem.Features.EndPoints.GetEndPoint.MappingProfile;
using HRSystem.Features.EndPoints.GetEndPoint.Query;
using HRSystem.Features.RoleFeature.CheckRoleFeature.Queries;
using HRSystem.Features.RoleFeature.GetFeaturesAssignedToRole.DTO;
using HRSystem.Features.RoleFeature.GetFeaturesAssignedToRole.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace HRSystem.Features.Common.RoleFeature.Filters.Auth
{
    public class CustomAuthorizedFilter : ActionFilterAttribute
    {
        private readonly IMediator _mediator;
        //private readonly SystemFeature _systemFeature;
        //private IMapper _mapper;

        public CustomAuthorizedFilter(IMediator mediator,IMapper mapper) 
        {
            this._mediator = mediator;
            //this._mapper = mapper;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userState =  context.HttpContext.RequestServices.GetRequiredService<UserStateViewModel>();



            var path= context.HttpContext.Request.Path.Value?.Trim().ToLower();
            if (!string.IsNullOrEmpty(path) && path.EndsWith("/")) path = path.TrimEnd('/');

            var methodType= context.HttpContext.Request.Method.ToUpper();
            var endpointdto = new EndPointDTO
            {
                Path = path,
                Method = methodType
            };
            var endpointExists = await _mediator.Send(new GetEndPointQuery(endpointdto));
            if(!endpointExists.IsSuccess)
            {
                context.Result = new ForbidResult();
                return;
            }

            var endpointFeatureIds = await _mediator.Send(new GetEndpointFeaturesQuery(endpointExists.Data.Id));
            if(!endpointFeatureIds.IsSuccess)
            {
                await next();
                return;
            }

            var userId =  context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            var roleClaim = context.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (Guid.TryParse(roleClaim, out var roleId))
            {
            }
            else
            {
                 context.Result = new ForbidResult();
                 return;
            }

       


            //var result = await _mediator.Send(new CheckRoleFeatureQuery((int)_systemFeature, Guid.Parse(roleId)));

            //if(!result.Data)
            //{
            //    context.Result = new ForbidResult();
            //    return;
            //}

            var roleFeatureIds = await _mediator.Send(new GetFeaturesAssignedToRoleQuery(roleId));
            if(!roleFeatureIds.IsSuccess)
            {
                context.Result = new ForbidResult();
                return;
            }
            await next();
        }
    }
}
