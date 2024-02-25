using Newtonsoft.Json;
using WeatherApp.Core.Interfaces;

namespace WeatherApp.Server.Configuration
{
	public class AppSettings : IAppSettings
	{
		[JsonProperty("weatherApiKey")]
		public string WeatherApiKey { get; set; } = string.Empty;
		
		[JsonProperty("baseWeatherUrl")]
		public string BaseWeatherUrl { get; set; } = string.Empty;
		[JsonProperty("baseForecastUrl")]
		public string BaseForecastUrl { get; set; } = string.Empty;
	}
}
