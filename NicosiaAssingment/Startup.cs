using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NicosiaAssingment.Configuration;
using NicosiaAssingment.DataAccess;
using NicosiaAssingment.DataAccess.Repositories;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Text.Json.Serialization;
using NicosiaAssingment.BusinessLogic.Services;

namespace NicosiaAssingment;

public class Startup
{
	private readonly IConfiguration _configuration;

	public Startup(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddSqlDbContext(_configuration);

		services.AddScoped<INicosiaContext, NicosiaContext>();
		services.AddScoped<INicosiaRepository, NicosiaRepository>();
		services.AddScoped<IPeopleService, PeopleService>();
		services.AddScoped<IAuthService, AuthService>();
		services.AddScoped<ICoursesService, CoursesService>();
		services.AddScoped<IMessagesService, MessagesService>();

		services.AddJwtAuthorization(_configuration);
		services.AddControllers()
			.AddJsonOptions(x =>
				x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
			);

		services.AddSwaggerDocumentation(Assembly.GetExecutingAssembly().GetName().Name + " API");

		services.AddAutoMapper(typeof(Startup).Assembly);
	}

	public void Configure(
		IApplicationBuilder app,
		ILogger<Startup> logger,
		INicosiaContext nicosiaContext)
	{
		app.UseHttpsRedirection();
		app.UseRouting();
		app.UseAuthentication();
		app.UseAuthorization();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllers();
		});

		app.UseSwagger();
		app.UseSwaggerUI(delegate (SwaggerUIOptions c)
		{
			c.SwaggerEndpoint("./swagger/v1/swagger.json", "Nicosia API");
			c.DocExpansion(DocExpansion.None);
			c.RoutePrefix = string.Empty;
		});

		nicosiaContext.EnsureCreated();
		nicosiaContext.Migrate();

		logger.LogInformation("Configure successful");
	}
}
