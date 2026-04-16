namespace MyTest;

public partial class MainPage : ContentPage
{

	Random random = new Random();

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object? sender, EventArgs e)
	{
		ColorRed.Value = random.Next(256);
		ColorGreen.Value = random.Next(256);
		ColorBlue. Value = random.Next(256);
	}
}
