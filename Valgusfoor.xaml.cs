namespace TARpv23;

public partial class ValgusfoorPage : ContentPage
{
    private bool isOn = false;
    private Label messageLabel;
    private Frame redLight, yellowLight, greenLight;

    public ValgusfoorPage()
    {
        Title = "Valgusfoor";

        messageLabel = new Label
        {
            Text = "K�igepealt l�lita valgusfoor sisse",
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 20
        };

        redLight = CreateLightFrame("punane", Colors.Gray);
        yellowLight = CreateLightFrame("kollane", Colors.Gray);
        greenLight = CreateLightFrame("roheline", Colors.Gray);

        Button sisseButton = new Button
        {
            Text = "SISSE",
            BackgroundColor = Colors.LightGray
        };
        sisseButton.Clicked += (s, e) => ToggleLights(true);

        Button valjaButton = new Button
        {
            Text = "V�LJA",
            BackgroundColor = Colors.LightGray
        };
        valjaButton.Clicked += (s, e) => ToggleLights(false);

        StackLayout lightsStack = new StackLayout
        {
            Children = { redLight, yellowLight, greenLight },
            Spacing = 20,
            VerticalOptions = LayoutOptions.CenterAndExpand
        };

        StackLayout buttonsStack = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Children = { sisseButton, valjaButton },
            HorizontalOptions = LayoutOptions.Center
        };

        Content = new StackLayout
        {
            Children = { messageLabel, lightsStack, buttonsStack },
            Padding = new Thickness(20)
        };
    }

    private Frame CreateLightFrame(string text, Color color)
    {
        var frame = new Frame
        {
            WidthRequest = 150,
            HeightRequest = 150,
            CornerRadius = 75,
            BackgroundColor = color,
            Content = new Label
            {
                Text = text,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }
        };

        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += (s, e) => ChangeText(frame);
        frame.GestureRecognizers.Add(tapGesture);

        return frame;
    }

    private void ToggleLights(bool turnOn)
    {
        isOn = turnOn;
        messageLabel.Text = turnOn ? "Valgusfoor on sisse l�litatud" : "K�igepealt l�lita valgusfoor sisse";
        redLight.BackgroundColor = turnOn ? Colors.Red : Colors.Gray;
        yellowLight.BackgroundColor = turnOn ? Colors.Yellow : Colors.Gray;
        greenLight.BackgroundColor = turnOn ? Colors.Green : Colors.Gray;
    }

    private void ChangeText(Frame frame)
    {
        if (!isOn)
        {
            messageLabel.Text = "K�igepealt l�lita valgusfoor sisse";
            return;
        }

        if (frame.Content is Label label)
        {
            if (frame.BackgroundColor == Colors.Red)
                label.Text = "Peatu";
            else if (frame.BackgroundColor == Colors.Yellow)
                label.Text = "Oota";
            else if (frame.BackgroundColor == Colors.Green)
                label.Text = "Mine";
        }
    }
}
