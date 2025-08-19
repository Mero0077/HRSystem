
using FluentValidation;
using HRSystem.Common;
using HRSystem.Common.AppDbContext;
//using HRSystem.Common.MessageBroker;
using HRSystem.Common.Middlewares;
using HRSystem.Common.Views;
using HRSystem.Features.Attendance.CheckIn.CheckInFilterInterceptor;
using HRSystem.Features.Auth.Jwt.Helper;
using HRSystem.Features.Branch.Create_Branch;
using HRSystem.Features.Common.RoleFeature.Filters.Auth;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Diagnostics;
using System.Reflection;

namespace HRSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("JWT KEY: " + Environment.GetEnvironmentVariable("JWT_SECRET_KEY"));

            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
               .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
               .EnableSensitiveDataLogging(true)
               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
               .UseLazyLoadingProxies());



            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            builder.Services.AddScoped<UserStateViewModel>();
            builder.Services.AddScoped<RequestHandlerBaseParameters>();
            builder.Services.AddScoped<TransactionMiddleWare>();
            builder.Services.AddScoped<CustomAuthorizedFilter>();
            builder.Services.AddScoped<TimeZoneFilter>();
            builder.Services.AddScoped(typeof(EndPointBaseParameters<>));
            builder.Services.AddValidatorsFromAssembly(typeof(CreateBranchRequestViewModelValidator).Assembly);
            builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddScoped(typeof(IGeneralRepository<>), typeof(GeneralRepository<>));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddJwtAuthentication(builder.Configuration);
            //builder.Services.AddSingleton<RabbitMqPublisher>();
            //builder.Services.AddHostedService<RabbitMqReceiver>();


            var app = builder.Build();
            //using (var scope = app.Services.CreateScope())
            //{
            //    var publisher = scope.ServiceProvider.GetRequiredService<RabbitMqPublisher>();
            //    await publisher.InitAsync();
            //}

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapScalarApiReference();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMiddleware<TransactionMiddleWare>();


            app.MapControllers();

            app.Run();
        }
    }
}
