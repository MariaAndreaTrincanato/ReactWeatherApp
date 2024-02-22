using Microsoft.AspNetCore.Mvc;
using WeatherApp.Server.Dtos;

namespace WeatherApp.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecastDto> Get()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
			{
				Timestamp = DateTime.Now,
				Temperature = Random.Shared.Next(-20, 55),
			})
			.ToArray();
		}
	}
}
