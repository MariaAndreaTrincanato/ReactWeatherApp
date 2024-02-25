using Newtonsoft.Json;

namespace WeatherApp.Domain.Entities;

public class WeatherResponse
{
    public int? Cod { get; set; }
    public string? Name { get; set; }
    public long? Id { get; set; }
    public int? Timezone { get; set; }
    public long? Dt { get; set; }
    public int? Visibility { get; set; }
    public string? Base { get; set; }
    
    public WeatherResponseItemWeather[] Weather { get; set; }
    public WeatherResponseItemSys? Sys { get; set; }
    public WeatherResponseItemWind? Wind { get; set; }
    public WeatherResponseItemClouds? Clouds { get; set; }
    public WeatherResponseItemCoord? Coord { get; set; }
    public WeatherResponseItemMain? Main { get; set; }

    public WeatherResponse()
    {
        this.Weather = Array.Empty<WeatherResponseItemWeather>();
    }
}

public class WeatherResponseItemWeather
{
    public long? Id { get; set; }
    public string? Main { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
}

public class WeatherResponseItemWind
{
    public decimal? Speed { get; set; }
    public int? Deg { get; set; }
}

public class WeatherResponseItemSys
{
    public int? Type { get; set; }
    public long? Id { get; set; }
    public string? Country { get; set; }
    public long? Sunrise { get; set; }
    public long? Sunset { get; set; }
}

public class WeatherResponseItemClouds
{
    public int? All { get; set; }
}

public class WeatherResponseItemCoord
{
    public decimal? Lat { get; set; }
    public decimal? Lon { get; set; }
}

public class WeatherResponseItemMain
{
    public decimal? Temp { get; set; }
    [JsonProperty("feels_like")]
    public decimal? FeelsLike { get; set; }
    [JsonProperty("temp_min")]
    public decimal? TempMin { get; set; }
    [JsonProperty("temp_max")]
    public decimal? TempMax { get; set; }
    public int? Pressure { get; set; }
    public decimal? Humidity { get; set; }
}
