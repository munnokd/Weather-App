public class WeatherData
{
    public string CityName { get; private set; }
    public float Temperature { get; private set; }
    public string Condition { get; private set; }
    public float Humidity { get; private set; }
    public float FeelsLike { get; private set; }

    public WeatherData(string cityName, float temperature, string condition,float humidity, float feelslike)
    {
        CityName = cityName;
        Temperature = temperature;
        Condition = condition;
        Humidity = humidity;
        FeelsLike = feelslike;
    }
}
