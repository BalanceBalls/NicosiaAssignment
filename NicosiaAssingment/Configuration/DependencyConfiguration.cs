using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NicosiaAssingment.DataAccess;
using NicosiaAssingment.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace NicosiaAssingment.Configuration;

public static class DependencyConfiguration
{
	public static IServiceCollection AddSqlDbContext(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString(nameof(NicosiaContext));

		services.AddDbContext<NicosiaContext>(
			builder =>
				builder.UseSqlServer(connectionString, options =>
				{
					options.EnableRetryOnFailure(
						maxRetryCount: 12,
						maxRetryDelay: TimeSpan.FromSeconds(30),
						errorNumbersToAdd: null);
				}));

		return services;
	}

	public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, string title = "Nicosia Api", string version = "v1.0")
	{
		services.AddSwaggerGen(delegate (SwaggerGenOptions c)
		{
			c.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = title,
				Version = version
			});
			c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				Name = "Authorization",
				Type = SecuritySchemeType.ApiKey,
				Description = "Enter your jwt below:",
				In = ParameterLocation.Header
			});
			c.AddSecurityRequirement(new OpenApiSecurityRequirement {
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						}
					},
					new List<string>()
				} });
		});

		return services;
	}

	public static IServiceCollection AddJwtAuthorization(this IServiceCollection services, IConfiguration config)
	{
		var jwt = config.GetSection("Jwt").Get<Jwt>();
		services.Configure<Jwt>(config.GetSection("Jwt"));
		services.AddAuthentication(auth =>
		{
			auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(options =>
		{
			options.SaveToken = true;
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidIssuer = jwt.Issuer,
				ValidateAudience = true,
				ValidAudience = jwt.Audience,
				ValidateIssuerSigningKey = true,
				ValidateLifetime= true,
				ClockSkew = TimeSpan.FromMinutes(0),
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SigningKey))
			};
		});

		return services;
	}
}
