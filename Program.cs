
using HRSystem.Common;
using HRSystem.Common.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;

namespace HRSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
               .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
               .EnableSensitiveDataLogging(true)
               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
               .UseLazyLoadingProxies());



            builder.Services.AddControllers();
            builder.Services.AddOpenApi();


            builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddScoped(typeof(IGeneralRepository<>), typeof(GeneralRepository<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
