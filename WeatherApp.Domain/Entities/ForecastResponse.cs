using Newtonsoft.Json;

namespace WeatherApp.Domain.Entities;

public class ForecastResponse
{
    public string? Cod { get; set; }
    public int? Message { get; set; }
    public int? Cnt { get; set; }
    public ForecastResponseItem[] List { get; set; }
    public ForecastResponseCity? City { get; set; }

    public ForecastResponse()
    {
        this.List = Array.Empty<ForecastResponseItem>();
    }
}

public class ForecastResponseCity
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public long? Sunrise { get; set; }
    public long? Sunset { get; set; }
}

public class ForecastResponseItem
{
    public long? Dt { get; set; }
    public int? Visibility { get; set; }
    [JsonProperty("dt_txt")]
    public string? DtTxt { get; set; }
    
    public ForecastResponseItemMain? Main { get; set; }
    public ForecastResponseItemWeather[] Weather { get; set; }
    public ForecastResponseItemClouds? Clouds { get; set; }
    public ForecastResponseItemWind? Wind { get; set; }
    public ForecastResponseItemSys? Sys { get; set; }

    public ForecastResponseItem()
    {
        this.Weather = Array.Empty<ForecastResponseItemWeather>();
    }
}

public class ForecastResponseItemMain
{
    public decimal? Temp { get; set; }
    [JsonProperty("feels_like")]
    public decimal? FeelsLike { get; set; }
    [JsonProperty("temp_min")]
    public decimal? TempMin { get; set; }
    [JsonProperty("temp_max")]
    public decimal? TempMax { get; set; }
    public int? Pressure { get; set; }
    [JsonProperty("sea_level")]
    public int? SeaLevel { get; set; }
    [JsonProperty("grnd_level")]
    public int? GrndLevel { get; set; }
    public decimal? Humidity { get; set; }
    [JsonProperty("temp_kf")]
    public decimal? TempKf { get; set; }
}

public class ForecastResponseItemWeather
{
    public long? Id { get; set; }
    public string? Main { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
}

public class ForecastResponseItemClouds
{
    public int? All { get; set; }
}

public class ForecastResponseItemWind
{
    public decimal? Speed { get; set; }
    public int? Deg { get; set; }
    public decimal? Gust { get; set; }
}

public class ForecastResponseItemSys
{
    public string? Pod { get; set; }
}