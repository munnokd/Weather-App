using SplashKitSDK;

public class ImageManager
{
    private Dictionary<string, Bitmap> _weatherIcons;

    public ImageManager()
    {
        _weatherIcons = new Dictionary<string, Bitmap>();
        LoadImages();
    }

    private void LoadImages()
    {
        _weatherIcons["Clear"] = SplashKit.LoadBitmap("sun", "Resources/images/sun.png");
        _weatherIcons["Clouds"] = SplashKit.LoadBitmap("clouds", "Resources/images/cloud.png");
        _weatherIcons["Rain"] = SplashKit.LoadBitmap("rain", "Resources/images/rain.png");
        _weatherIcons["Snow"] = SplashKit.LoadBitmap("snow", "Resources/images/snow.png");
    }

    public void DisplayWeatherIcon(string condition)
    {
        if (_weatherIcons.ContainsKey(condition))
        {
            Bitmap weatherIcon = _weatherIcons[condition];

            DrawingOptions options = SplashKit.OptionScaleBmp(0.2, 0.2);

            SplashKit.DrawBitmap(weatherIcon, 10, 20, options);
        }
    }

}
