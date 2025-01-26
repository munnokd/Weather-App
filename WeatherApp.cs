using SplashKitSDK;
using System.Threading.Tasks;

namespace WeatherApp
{
public class WeatherApp
    {
        private WeatherService _weatherService;
        private WeatherDisplay _weatherDisplay;
        private InputManager _inputManager;
        private TextBox _textBox;

        private bool _isFetchingWeather = false;
        private WeatherData _currentWeather;
        private string _statusMessage = "Please enter a city name to get the weather";

        public WeatherApp()
        {
            _weatherService = new WeatherService();
            _weatherDisplay = new WeatherDisplay();
            _textBox = new TextBox(20, 50, 200, 30);  
            _inputManager = new InputManager(_textBox); 
        }

        public void Run()
        {
            Window weatherWindow = new Window("Weather UI App", 800, 600);

            while (!weatherWindow.CloseRequested)
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);

                _textBox.HandleInput();
                _textBox.Render();

                if (_isFetchingWeather)
                {
                    SplashKit.DrawText("Fetching weather data, please wait...", Color.Black, 20, 20);
                }
                else
                {
                    SplashKit.DrawText(_statusMessage, Color.Black, 20, 90);

                    if (SplashKit.KeyTyped(KeyCode.ReturnKey) && !_isFetchingWeather)
                    {
                        string cityName = _inputManager.GetCityInput();
                        if (!string.IsNullOrEmpty(cityName))
                        {
                            FetchWeatherAsync(cityName);
                        }
                    }
                }

                if (_currentWeather != null)
                {
                    _weatherDisplay.Render(_currentWeather);
                }

                weatherWindow.Refresh(60);
            }

            weatherWindow.Close();
        }

        private async void FetchWeatherAsync(string cityName)
        {
            _isFetchingWeather = true;
            _statusMessage = $"Fetching weather for {cityName}...";

            try
            {
                _currentWeather = await _weatherService.FetchWeather(cityName);

                if (_currentWeather != null)
                {
                    _statusMessage = $"Weather fetched for {cityName}";
                }
                else
                {
                    _statusMessage = "Failed to fetch weather data. Try again.";
                }
            }
            catch
            {
                _statusMessage = "Failed to fetch weather data. Check the city name or your connection.";
            }
            finally
            {
                _isFetchingWeather = false;
            }
        }
    }
}
