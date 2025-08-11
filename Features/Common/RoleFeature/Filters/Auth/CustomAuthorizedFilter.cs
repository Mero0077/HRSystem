using HRSystem.Common.Enums;
using HRSystem.Features.RoleFeature.CheckRoleFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace HRSystem.Features.Common.RoleFeature.Filters.Auth
{
    public class CustomAuthorizedFilter : ActionFilterAttribute
    {
        private readonly IMediator _mediator;
        private readonly SystemFeature _systemFeature;

        public CustomAuthorizedFilter(IMediator mediator,SystemFeature systemFeature) 
        {
            this._mediator = mediator;
            this._systemFeature = systemFeature;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userId =  context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            var roleId = context.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            if (string.IsNullOrEmpty(roleId))
            {
                context.Result = new ForbidResult();
                return;
            }
            var result = await _mediator.Send(
                  new CheckRoleFeatureQuery((int)_systemFeature, Guid.Parse(roleId))
              );

            if(!result.Data)
            {
                context.Result = new ForbidResult();
                return;
            }
            await next();
        }
    }
}
