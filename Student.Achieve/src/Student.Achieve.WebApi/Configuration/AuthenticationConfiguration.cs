﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Student.Achieve.Infrastructure.Security.Authentication;
using System.Text;

namespace Student.Achieve.WebApi.Configuration
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection AddAuthenticationWithJwt(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var config = configuration.GetSection(JwtSecurityTokenOptions.Name);
            services.Configure<JwtSecurityTokenOptions>(config);
            var options = config.Get<JwtSecurityTokenOptions>();

            var key = Encoding.ASCII.GetBytes(options.SecretKey);

            services.AddAuthentication(config => config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(config =>
                    {
                        config.RequireHttpsMetadata = false;
                        config.SaveToken = true;
                        config.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            ValidateLifetime = true,
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidIssuer = options.Issuer,
                            ValidAudiences = options.Audiences
                        };
                    });

            return services;
        }
    }
}