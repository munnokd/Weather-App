using SplashKitSDK;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class WeatherService
{
    private static string apiKey = "35aba739be0b90334b82e247ef63f71b"; 

    public async Task<WeatherData> FetchWeather(string cityName)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return ParseWeatherData(responseBody);
        }
    }

    private WeatherData ParseWeatherData(string json)
    {
        JObject weatherJson = JObject.Parse(json);
        float temperature = weatherJson["main"]["temp"].ToObject<float>();
        float feels_like = weatherJson["main"]["feels_like"].ToObject<float>();
        string condition = weatherJson["weather"][0]["main"].ToString();
        string cityName = weatherJson["name"].ToString();
        float humidity = weatherJson["main"]["humidity"].ToObject<float>();

        return new WeatherData(cityName, temperature, condition,humidity,feels_like);
    }
}
