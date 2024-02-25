namespace WeatherApp.Server.Helpers;

public static class DateHelper
{
    public static DateTimeOffset GetDateTimeFromUnixTimestamp(long value)
    {   
        return DateTimeOffset.FromUnixTimeSeconds(value);
    }
}