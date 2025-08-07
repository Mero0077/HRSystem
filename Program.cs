
using FluentValidation;
using HRSystem.Common;
using HRSystem.Common.AppDbContext;
using HRSystem.Features.Auth.Jwt.Helper;
using HRSystem.Features.Branch.Create_Branch;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Diagnostics;
using System.Reflection;

namespace HRSystem
{
    public class Program
    {
        public static void Main(string[] args)
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

            builder.Services.AddScoped<RequestHandlerBaseParameters>();
            builder.Services.AddScoped(typeof(EndPointBaseParameters<>));
            builder.Services.AddValidatorsFromAssembly(typeof(CreateBranchRequestViewModelValidator).Assembly);
            builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddScoped(typeof(IGeneralRepository<>), typeof(GeneralRepository<>));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddJwtAuthentication(builder.Configuration);
            
                var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapScalarApiReference();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
