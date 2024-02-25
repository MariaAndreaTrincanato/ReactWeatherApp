namespace WeatherApp.Core.Interfaces;

public interface IAppSettings
{
    public string WeatherApiKey { get; set; }
    public string BaseWeatherUrl { get; set; }
    public string BaseForecastUrl { get; set; }
}
