using Newtonsoft.Json;

namespace WeatherApp.Server.Configuration
{
	public class AppSettings
	{
		[JsonProperty("weatherApiKey")]
		public string WeatherApiKey { get; set; } = string.Empty;
		
		[JsonProperty("baseWeatherUrl")]
		public string BaseWeatherUrl { get; set; } = string.Empty;
	}
}
