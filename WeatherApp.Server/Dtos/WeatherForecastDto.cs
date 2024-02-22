namespace WeatherApp.Server.Dtos
{
	public class WeatherForecastDto
	{
		public WeatherForecastDto() { }

		public DateTime Timestamp { get; set; }
		public decimal Temperature { get; set; }
	}
}
