using WeatherApp.Core.Helpers;
using WeatherApp.Core.Interfaces;

namespace WeatherApp.Core.Tests;

public class UriHelperTests
{
    [Theory]
    [InlineData("udine", "metric", "baseWeatherUrl?appId=000&units=metric&q=udine")]
    [InlineData(null, null, "baseWeatherUrl?appId=000&units=&q=")]
    public void UriHelper_BuildWeatherUri(string cityName, string units, string expected)
    {
        // Arrange
        var settings = new CustomAppSettings();
        
        // Act
        var result = UriHelper.BuildWeatherUri(settings, cityName, units);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("udine", "metric", "baseForecastUrl?appId=000&units=metric&q=udine")]
    [InlineData(null, null, "baseForecastUrl?appId=000&units=&q=")]
    public void UriHelper_BuildForecastUri(string cityName, string units, string expected)
    {
        // Arrange
        var settings = new CustomAppSettings();
        
        // Act
        var result = UriHelper.BuildForecastUri(settings, cityName, units);

        // Assert
        Assert.Equal(expected, result);
    }
}

public class CustomAppSettings : IAppSettings
{
    public string WeatherApiKey { get; set; } = "000";
    public string BaseWeatherUrl { get; set; } = "baseWeatherUrl";
    public string BaseForecastUrl { get; set; } = "baseForecastUrl";
    public string IconsUrl { get; set; } = "";
}