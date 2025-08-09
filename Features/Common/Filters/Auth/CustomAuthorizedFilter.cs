using Microsoft.AspNetCore.Mvc.Filters;

namespace HRSystem.Features.Common.Filters.Auth
{
    public class CustomAuthorizedFilter : ActionFilterAttribute
    {
        public CustomAuthorizedFilter() 
        { 
        }
    }
}
