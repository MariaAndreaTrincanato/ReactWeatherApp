using System.Net.Http.Headers;
using System.Text.Json;
using Newtonsoft.Json;

namespace WeatherApp.Domain.Http;

public static class ClientExtensions
{
    public static void Configure(this HttpClient client, string apiBaseAddress, bool jsonHeader = true)
    {
        if (string.IsNullOrWhiteSpace(apiBaseAddress))
        {
            throw new ArgumentNullException(nameof(apiBaseAddress));
        }

        client.BaseAddress = new Uri(apiBaseAddress);
        client.DefaultRequestHeaders.Accept.Clear();
        if (jsonHeader)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }

    private static async Task<string> GetStringAsync(this HttpClient client, string api)
    {
        var response = await client.GetAsync(api);
        return await response.Content.ReadAsStringAsync();
    }

    public static async Task<TOutput?> GetAsync<TOutput>(this HttpClient client, string api)
        where TOutput : class
    {
        var responseString = await GetStringAsync(client, api);
        return JsonConvert.DeserializeObject<TOutput>(responseString);
    }
}