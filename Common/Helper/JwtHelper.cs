using HRSystem.Common.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Text;

namespace HRSystem.Common.Helper
{
    public static class JwtHelper
    {
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            var jwtSecretKey = Environment.GetEnvironmentVariable(Constants.Constants.JwtKeyName);
            if(string.IsNullOrEmpty(jwtSecretKey))
                throw new Exception("JWT_SECRET_KEY is not set in environment variables.");
            var encodeSecretey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey));
            return encodeSecretey;
        }
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,IConfiguration configuration)
        {

            services.Configure<JwtOptions>(configuration.GetSection("Jwt"));

            var sp = services.BuildServiceProvider();
            var jwtOptions = sp.GetRequiredService<IOptions<JwtOptions>>().Value;

            var key = GetSymmetricSecurityKey();

            services.AddAuthentication(
                opt => {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    }
                ).AddJwtBearer(options=>
                {
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = true,
                        ValidAudience = jwtOptions.Audience,
                        ValidateIssuer = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidateLifetime = true,
                    };
                });
          return services;
        }
    }
}
