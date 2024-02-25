namespace WeatherApp.Domain.Http;

public abstract class ClientBase : IDisposable
{
    private HttpClient _client;

    protected HttpClient Client
    {
        get { return _client; }
    }
    
    public ClientBase(HttpClient client, string apiBaseAddress)
    {
        _client = client;
        _client.Configure(apiBaseAddress, jsonHeader: true);
    }
    
    public void Dispose()
    {
        // _client = null;
    }
}
