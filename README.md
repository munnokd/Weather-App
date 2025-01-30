## UI Of APP

![image](https://github.com/user-attachments/assets/1ff8b799-bc4c-4f60-bcd5-b427b53f08c5)
![image](https://github.com/user-attachments/assets/4306f381-f780-4020-bd44-2ba16f611598)
![image](https://github.com/user-attachments/assets/8dc591a7-33ee-40bd-8a50-cc7a3ef595f0)

## Steps to call API's using splashkit

### 1. API calling
```cs
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
```

### 2. API data parsing
```cs
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
```

### 3. API calling async function
```cs
   _currentWeather = await _weatherService.FetchWeather(cityName);
```

## Link of video tutorial
https://deakin.au.panopto.com/Panopto/Pages/Viewer.aspx?id=d93c59f32bf6-44f4-b94f-b2710017ea45


