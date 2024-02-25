namespace WeatherApp.Server.Dtos
{
	public class WeatherDto
	{
		public WeatherDto() { }

		public DateTime Timestamp { get; set; }
		public decimal Temperature { get; set; }
	}
}
