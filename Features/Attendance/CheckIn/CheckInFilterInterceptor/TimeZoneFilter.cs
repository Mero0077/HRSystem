using Azure.Core;
using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Interfaces;
using HRSystem.Features.Attendance.CheckIn.ClockInEmployee.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using TimeZoneConverter;

namespace HRSystem.Features.Attendance.CheckIn.CheckInFilterInterceptor
{
    public class TimeZoneFilter : ActionFilterAttribute
    {
        public TimeZoneFilter(IGeneralRepository<Models.Employee> general)
        {

            _EmployeeRepository = general;
        }

        private IGeneralRepository<Models.Employee> _EmployeeRepository { get; set; }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var req = context.ActionArguments.Values.OfType<ITimeZoneUTC>().FirstOrDefault();
            if (req == null)
            {
                context.Result = new BadRequestObjectResult("no data");
                return;
            }

            var TimeZone = await _EmployeeRepository.Get(e => e.Id == req.EmpId).
                       Select(e => e.User.TimeZone).FirstOrDefaultAsync();

            if (TimeZone == null)
            {
                context.Result = new NotFoundResult();
                return;
            }


            var windowsId = TZConvert.IanaToWindows(TimeZone); // redo
            var info = TimeZoneInfo.FindSystemTimeZoneById(windowsId);

            if (req.CheckInTime.HasValue)
            {
                //req.CheckInTime = TimeZoneInfo.ConvertTime(req.CheckInTime.Value, info, TimeZoneInfo.Utc);

                var localTime = req.CheckInTime.Value;
                var offset = info.GetUtcOffset(localTime.DateTime);
                req.CheckInTime = localTime.ToOffset(offset);
            }
            if(req.CheckOutTime.HasValue)
            {
                //req.CheckOutTime = TimeZoneInfo.ConvertTimeToUtc(req.CheckOutTime.Value, info);

                var localTime = req.CheckOutTime.Value;
                var offset = info.GetUtcOffset(localTime.DateTime); 
                req.CheckOutTime = localTime.ToOffset(offset);
            }


            await next();
        }
    }
}
