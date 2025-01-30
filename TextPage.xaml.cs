using static System.Net.Mime.MediaTypeNames;

namespace TARpv23;

public partial class TextPage : ContentPage
{
	Label lbl;
	Editor editor;
	HorizontalStackLayout hsl;
	List<string> buttons = new List<string> { "Tagasi", "Avaleht", "Edasi"};
	public TextPage(int k)
	{
		lbl = new Label();
		{
            Text = "Pealkiri",
			TextColor = Color.FromRgb(100, 10, 10),
			FontFamily = "Socafe 400",
		};
		//InitializeComponent();
		


    }
}