namespace WeatherApp.Server.Dtos
{
	public class WeatherDto
	{
		public WeatherDto()
		{
			this.Name = string.Empty;
			this.Country = string.Empty;
		}

		public DateTimeOffset? Timestamp { get; set; }
		public decimal? Temperature { get; set; }
		public decimal? TemperatureMin { get; set; }
		public decimal? TemperatureMax { get; set; }
		public decimal? FeelsLike { get; set; }
		
		public string Name { get; set; }
		public string Country { get; set; }
		
		public int? Pressure { get; set; }
		public decimal? Humidity { get; set; }
		
		public DateTimeOffset? Sunrise { get; set; }
		public DateTimeOffset? Sunset { get; set; }
		
		public WeatherDescriptionDto Description { get; set; }
		
	}

	public class WeatherDescriptionDto
	{
		public string Conditions { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }

		public WeatherDescriptionDto()
		{
			this.Conditions = string.Empty;
			this.Description = string.Empty;
			this.Icon = string.Empty;
		}
	}
}
