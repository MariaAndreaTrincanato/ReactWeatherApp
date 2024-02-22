
using Microsoft.AspNetCore;

namespace WeatherApp.Server
{
	public class Program
	{

		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
					WebHost.CreateDefaultBuilder(args)
						.ConfigureAppConfiguration((hostingContext, config) =>
						{
							config.AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);
						})
						.UseIIS()
						.UseStartup<Startup>();

	}
}
