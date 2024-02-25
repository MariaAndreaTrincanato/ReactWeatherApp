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
        DateTimeOffset? timestamp = null;

        if (weather.Dt is not null)
        {
            timestamp = DateHelper.GetDateTimeFromUnixTimestamp(weather.Dt.Value);
        }
        
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
                Conditions = weather.Weather.First().Main ?? DataConst.DefaultData,
                Description = weather.Weather.First().Description ?? DataConst.DefaultData,
                Icon = weather.Weather.First().Icon ?? DataConst.DefaultData
            };
        }
        
        return new WeatherDto
        {
            Timestamp = timestamp,
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
            Name = forecast.City?.Name ?? DataConst.DefaultName,
            Country = forecast.City?.Country ?? DataConst.DefaultCountry,
            Forecast = forecast.List.Select(x =>
            {
                DateTimeOffset? timestamp = null;
                if (x.Dt is not null)
                {
                    timestamp = DateHelper.GetDateTimeFromUnixTimestamp(x.Dt.Value);
                }
                
                var description = new WeatherDescriptionDto();
                if (x.Weather.Length > 0)
                {
                    description = new WeatherDescriptionDto
                    {
                        Conditions = x.Weather.First().Main ?? DataConst.DefaultData,
                        Description = x.Weather.First().Description ?? DataConst.DefaultData,
                        Icon = x.Weather.First().Icon ?? DataConst.DefaultData
                    };
                }
                
                return new WeatherDto
                {
                    Timestamp = timestamp,
                    Description = description,
                    Temperature = x.Main?.Temp,
                    TemperatureMin = x.Main?.TempMin,
                    TemperatureMax = x.Main?.TempMax,
                    FeelsLike = x.Main?.FeelsLike,
                    Pressure = x.Main?.Pressure,
                    Humidity = x.Main?.Humidity,
                    Name = forecast.City?.Name ?? DataConst.DefaultName,
                    Country = forecast.City?.Country ?? DataConst.DefaultCountry
                };
            }).ToArray()
        };
    }
}