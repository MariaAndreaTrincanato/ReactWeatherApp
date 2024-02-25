using WeatherApp.Domain.Entities;

namespace WeatherApp.Domain.Http;

public class WeatherClient : ClientBase
{
    private string _api { get; set; }

    public WeatherClient(HttpClient client, string apiBaseAddress) : base(client, apiBaseAddress)
    {
        this._api = apiBaseAddress;
    }

    public async Task<ForecastResponse?> GetWeatherForecast()
    {
        ForecastResponse? response;
        response = await this.Client.GetAsync<ForecastResponse>(this._api);
        return response;
    }
}