namespace TARpv23;

public partial class StepperSliderPage : ContentPage
{
    Label lbl;
    Slider sl;
    Stepper st;
    AbsoluteLayout abs;

    public StepperSliderPage(int k)
    {
        lbl = new Label
        {
            BackgroundColor = Color.FromRgb(120, 144, 133),
            Text = "..."
        };

        sl = new Slider
        {
            Minimum = 0,
            Maximum = 100,
            Value = 25,
            MinimumTrackColor = Color.FromRgb(55, 55, 55),
            MaximumTrackColor = Color.FromRgb(0, 0, 0),
            ThumbColor = Color.FromRgb(155, 155, 155),
        };
        sl.ValueChanged += SL_ValueChanged;

        st = new Stepper
        {
            Minimum = 0,
            Maximum = 100,
            Increment = 5,
            Value = 25,
            HorizontalOptions = LayoutOptions.CenterAndExpand
        };
        st.ValueChanged += SL_ValueChanged;

        abs = new AbsoluteLayout { Children = { lbl, sl, st } };
        AbsoluteLayout.SetLayoutBounds(lbl, new Rect(10, 100, 300, 50));
        AbsoluteLayout.SetLayoutBounds(sl, new Rect(10, 300, 300, 50));
        AbsoluteLayout.SetLayoutBounds(st, new Rect(10, 400, 300, 50));

        Content = abs;
    }

    private void SL_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lbl.Text = string.Format("{0:F1}", e.NewValue);
        lbl.FontSize = e.NewValue;
        lbl.Rotation = e.NewValue;
    }
}
