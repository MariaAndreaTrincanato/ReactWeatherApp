using Microsoft.AspNetCore.Mvc;
using WeatherApp.Server.Dtos;
using WeatherApp.Server.Services;

namespace WeatherApp.Server.Controllers
{
	[ApiController]
	[Route("[controller]")] // api/v1/
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;
		private readonly WeatherForecastDtoService _weatherForecastDtoService;

		public WeatherForecastController(
			ILogger<WeatherForecastController> logger,
			WeatherForecastDtoService weatherForecastDtoService)
		{
			_logger = logger;
			_weatherForecastDtoService = weatherForecastDtoService;
		}

		[HttpGet("[action]/{cityName}/{units}")]
		public async Task<WeatherDto> GetWeather(string cityName, string units)
		{
			return await _weatherForecastDtoService.GetWeatherAsync(cityName, units);
		}
		
		[HttpGet("[action]/{cityName}/{units}")]
		public async Task<ForecastDto> GetForecast(string cityName, string units)
		{
			return await _weatherForecastDtoService.GetForecastAsync(cityName, units);
		}
	}
}
