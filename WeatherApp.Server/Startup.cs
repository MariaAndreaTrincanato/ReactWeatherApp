using Microsoft.Extensions.Options;
using WeatherApp.Core;
using WeatherApp.Core.Interfaces;
using WeatherApp.Server.Configuration;

namespace WeatherApp.Server
{
	public class Startup
	{
		public IConfiguration Configuration { get;  set; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			var appSettingsSection = Configuration.GetSection("AppSettings");
			services.Configure<AppSettings>(appSettingsSection);

			services.AddSingleton<IAppSettings>(s => 
				s.GetRequiredService<IOptions<AppSettings>>().Value);

			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			services.AddApiServices();
			services.AddCoreServices();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDefaultFiles();
			app.UseStaticFiles();

			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
									name: "default_v1",
									pattern: "api/v1/{controller}/{action=Index}/{id?}");
			});
		}
	}
}
