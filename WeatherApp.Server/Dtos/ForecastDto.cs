using WeatherApp.Server.Constants;

namespace WeatherApp.Server.Dtos;

public class ForecastDto
{
    public string Name { get; set; }
    public string Country { get; set; }
    public WeatherDto[] Forecast { get; set; }

    public ForecastDto()
    {
        this.Name = DataConst.DefaultName;
        this.Country = DataConst.DefaultCountry;
        this.Forecast = Array.Empty<WeatherDto>();
    }
}