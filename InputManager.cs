using SplashKitSDK;

public class InputManager
{
    private TextBox _textBox;

        public InputManager(TextBox textBox)
        {
            _textBox = textBox;
        }

        public string GetCityInput()
        {
            return _textBox.Text;
        }

}

public class TextBox
{
    private int _x, _y, _width, _height;
    private bool _isActive;
    public string Text { get; private set; } = "";

    public TextBox(int x, int y, int width, int height)
    {
        _x = x;
        _y = y;
        _width = width;
        _height = height;
        _isActive = false;
    }

    public void HandleInput()
    {
        if (SplashKit.MouseClicked(MouseButton.LeftButton))
        {
            if (SplashKit.PointInRectangle(SplashKit.MousePosition(), SplashKit.RectangleFrom(_x, _y, _width, _height)))
            {
                _isActive = true; 
            }
            else
            {
                _isActive = false; 
            }
        }

        if (_isActive)
        {
            if (SplashKit.KeyTyped(KeyCode.BackspaceKey) && Text.Length > 0)
            {
                Text = Text.Substring(0, Text.Length - 1);
            }

            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                char? keyChar = KeyToChar(key);
                if (keyChar.HasValue && SplashKit.KeyTyped(key))
                {
                    Text += keyChar.Value;
                }
            }
        }
    }

    public void Render()
    {
        Color boxColor = _isActive ? Color.LightBlue : Color.Gray;
        SplashKit.FillRectangle(boxColor, _x, _y, _width, _height);

        SplashKit.DrawText(Text, Color.Black, _x + 5, _y + 5);
    }

    private char? KeyToChar(KeyCode key)
    {
        if (key >= KeyCode.AKey && key <= KeyCode.ZKey)
        {
            return (char)('A' + (key - KeyCode.AKey)); 
        }
        if (key >= KeyCode.Num0Key && key <= KeyCode.Num9Key)
        {
            return (char)('0' + (key - KeyCode.Num0Key)); 
        }
        if (key == KeyCode.SpaceKey)
        {
            return ' '; 
        }
        return null; 
    }
}
