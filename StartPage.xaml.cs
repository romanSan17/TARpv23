namespace TARpv23;

public partial class StartPage : ContentPage
{
    public List<ContentPage> lehed = new List<ContentPage>()
    {
        new TextPage(0),
        new FigurePage(1),
        new Valgusfoor(2)
    };

    public List<string> tekstid = new List<string>
    {
        "Tee lahti TekstPage",
        "Tee lahti FigurePage",
        "Tee lahti Valgusfoor"
    };

    ScrollView sv;
    VerticalStackLayout vsl;

    public StartPage()
    {
        Title = "Avaleht";
        vsl = new VerticalStackLayout { BackgroundColor = Color.FromRgb(150, 100, 20) };

        for (int i = 0; i < tekstid.Count; i++)
        {
            Button nupp = new Button
            {
                Text = tekstid[i],
                BackgroundColor = Color.FromRgb(100 + (i * 30), 100, 20), 
                TextColor = Color.FromRgb(10, 160, 160),
                BorderWidth = 2,
                ZIndex = i, 
                FontFamily = "Arial"
            };

            
            vsl.Add(nupp);
            nupp.Clicked += Lehte_avamine;
        }

        sv = new ScrollView { Content = vsl };
        Content = sv;
    }

    private async void Lehte_avamine(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            int index = btn.ZIndex;
            if (index >= 0 && index < lehed.Count)
            {
                await Navigation.PushAsync(lehed[index]);
            }
        }
    }
}
