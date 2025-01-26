using SplashKitSDK;
public class WeatherDisplay
{
    private ImageManager _imageManager;

    public WeatherDisplay()
    {
        _imageManager = new ImageManager();
    }

    public void Render(WeatherData weatherData)
    {
        SplashKit.DrawText($"City: {weatherData.CityName}", Color.Black, 20, 70);
        SplashKit.DrawText($"Temperature: {weatherData.Temperature} °C", Color.Black, 20, 120);
        SplashKit.DrawText($"Feels Like: {weatherData.FeelsLike} °C", Color.Black, 20, 135);
        SplashKit.DrawText($"Humidity: {weatherData.Humidity}", Color.Black, 20, 150);
        SplashKit.DrawText($"Condition: {weatherData.Condition}", Color.Black, 20, 170);

        _imageManager.DisplayWeatherIcon(weatherData.Condition);
    }
}
