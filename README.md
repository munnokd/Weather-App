## UI Of APP

![image](https://github.com/user-attachments/assets/1ff8b799-bc4c-4f60-bcd5-b427b53f08c5)
![image](https://github.com/user-attachments/assets/4306f381-f780-4020-bd44-2ba16f611598)
![image](https://github.com/user-attachments/assets/8dc591a7-33ee-40bd-8a50-cc7a3ef595f0)

## Details of API
APIs are the endpoints from which users can get data from the server. Users don't need to create any server or write any code rather they just simply call the API end points by which they can access data. For accessing api user need to give authentication either in the form of cookies or key. In this app I user openweather API which is accessed using key. When user call this api then users get data in the form of json. Below is that api which I used to get data from server

API: http://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric

Below is the form of data that I got from the server when I called this above API: 
```json
{
    "coord":
    {
        "lon": 151.2073,
        "lat": -33.8679
    },
    "weather":
    [
        {
            "id": 800,
            "main": "Clear",
            "description": "clear sky",
            "icon": "01n"
        }
    ],
    "base": "stations",
    "main":
    {
        "temp": 22.09,
        "feels_like": 22.5,
        "temp_min": 21.33,
        "temp_max": 22.43,
        "pressure": 1020,
        "humidity": 82,
        "sea_level": 1020,
        "grnd_level": 1015
    },
    "visibility": 10000,
    "wind":
    {
        "speed": 5.14,
        "deg": 150
    },
    "clouds":
    {
        "all": 0
    },
    "dt": 1738329540,
    "sys":
    {
        "type": 2,
        "id": 2018875,
        "country": "AU",
        "sunrise": 1738350990,
        "sunset": 1738400448
    },
    "timezone": 39600,
    "id": 2147714,
    "name": "Sydney",
    "cod": 200
}

```
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
[https://deakin.au.panopto.com/Panopto/Pages/Viewer.aspx?id=d93c59f3-2bf6-44f4-b94f-b2710017ea45](https://deakin.au.panopto.com/Panopto/Pages/Viewer.aspx?id=d93c59f3-2bf6-44f4-b94f-b2710017ea45)

