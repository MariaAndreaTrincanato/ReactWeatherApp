using WeatherApp.Domain.Entities;
using WeatherApp.Server.Constants;
using WeatherApp.Server.Dtos;
using WeatherApp.Server.Helpers;

namespace WeatherApp.Server.Extensions;

public static class MapEntityToDtoExtensions
{
    public static WeatherDto MapToWeatherDto(this WeatherResponse weather)
    {
        DateTimeOffset? sunrise = null;
        DateTimeOffset? sunset = null;
        
        if (weather.Sys is not null)
        {
            if (weather.Sys.Sunrise is not null)
            {
                sunrise = DateHelper.GetDateTimeFromUnixTimestamp(weather.Sys.Sunrise.Value);
            }

            if (weather.Sys.Sunset is not null)
            {
                sunset = DateHelper.GetDateTimeFromUnixTimestamp(weather.Sys.Sunset.Value);
            }
        }

        var description = new WeatherDescriptionDto();
        if (weather.Weather.Length > 0)
        {
            description = new WeatherDescriptionDto
            {
                Conditions = weather.Weather.First().Main,
                Description = weather.Weather.First().Description,
                Icon = weather.Weather.First().Icon
            };
        }
        
        return new WeatherDto
        {
            Temperature = weather.Main?.Temp,
            TemperatureMin = weather.Main?.TempMin,
            TemperatureMax = weather.Main?.TempMax,
            FeelsLike = weather.Main?.FeelsLike,
            Name = weather.Name ?? DataConst.DefaultName,
            Country = weather.Sys?.Country ?? DataConst.DefaultCountry,
            Pressure = weather.Main?.Pressure,
            Humidity = weather.Main?.Humidity,
            Sunrise = sunrise,
            Sunset = sunset,
            Description = description
        };
    }
    
    public static ForecastDto MapToForecastDto(this ForecastResponse forecast)
    {
        return new ForecastDto
        {
            // TODO
        };
    }
}