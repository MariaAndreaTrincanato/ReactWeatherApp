using WeatherApp.Core.Interfaces;

namespace WeatherApp.Core.Helpers;

public static class UriHelper
{
    public static string BuildWeatherUri(IAppSettings appSettings, string cityName, string units)
    {
        return $"{appSettings.BaseWeatherUrl}?appId={appSettings.WeatherApiKey}&units={units}&q={cityName}";
    }
    
    public static string BuildForecastUri(IAppSettings appSettings, long id, string units)
    {
        return $"{appSettings.BaseForecastUrl}?appId={appSettings.WeatherApiKey}&units={units}&id={id}";
    }
}
