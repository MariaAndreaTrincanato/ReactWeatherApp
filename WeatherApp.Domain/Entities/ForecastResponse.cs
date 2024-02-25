using System.Text.Json.Serialization;

namespace WeatherApp.Domain.Entities;

public class ForecastResponse
{
    public string? Cod { get; set; }
    public int? Message { get; set; }
    public int? Cnt { get; set; }
    public OpenWeatherResponseItem[] List { get; set; }

    public ForecastResponse()
    {
        this.List = Array.Empty<OpenWeatherResponseItem>();
    }
}

public class OpenWeatherResponseItem
{
    public string? Dt { get; set; } = string.Empty;
    public int? Visibility { get; set; }
    [JsonPropertyName("dt_txt")]
    public string? DtTxt { get; set; }
    
    public OpenWeatherResponseItemMain? Main { get; set; }
    public OpenWeatherResponseItemWeather? Weather { get; set; }
    public OpenWeatherResponseItemClouds? Clouds { get; set; }
    public OpenWeatherResponseItemWind? Wind { get; set; }
    public OpenWeatherResponseItemSys? Sys { get; set; }
}

public class OpenWeatherResponseItemMain
{
    [JsonPropertyName("temp")]
    public decimal? Temp { get; set; }
    [JsonPropertyName("feels_like")]
    public decimal? FeelsLike { get; set; }
    [JsonPropertyName("temp_min")]
    public decimal? TempMin { get; set; }
    [JsonPropertyName("temp_max")]
    public decimal? TempMax { get; set; }
    [JsonPropertyName("pressure")]
    public int? Pressure { get; set; }
    [JsonPropertyName("sea_level")]
    public int? SeaLevel { get; set; }
    [JsonPropertyName("grnd_level")]
    public int? GrndLevel { get; set; }
    [JsonPropertyName("humidity")]
    public decimal? Humidity { get; set; }
    [JsonPropertyName("temp_kf")]
    public decimal? TempKf { get; set; }
}

public class OpenWeatherResponseItemWeather
{
    public long? Id { get; set; }
    public string? Main { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
}

public class OpenWeatherResponseItemClouds
{
    public int? All { get; set; }
}

public class OpenWeatherResponseItemWind
{
    public decimal? Speed { get; set; }
    public int? Deg { get; set; }
    public decimal? Gust { get; set; }
}

public class OpenWeatherResponseItemSys
{
    public string? Pod { get; set; }
}