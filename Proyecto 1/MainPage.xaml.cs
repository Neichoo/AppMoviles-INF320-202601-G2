namespace MyTest;

public partial class MainPage : ContentPage
{

	Random random = new Random();

	public MainPage()
	{
		InitializeComponent();
		ActualizarColorYValores();
	}

	private void OnCounterClicked(object? sender, EventArgs e)
	{
		ColorRed.Value = random.Next(256);
		ColorGreen.Value = random.Next(256);
		ColorBlue.Value = random.Next(256);

		ActualizarColorYValores();
	}

	private void AlCambiarValorSlider(object? sender, ValueChangedEventArgs e)
	{
		ActualizarColorYValores();
	}

	private async void AlCopiarHexadecimalClicked(object? sender, EventArgs e)
	{
		await Clipboard.Default.SetTextAsync(EtiquetaHexadecimal.Text ?? "#000000");
		await DisplayAlertAsync("Copiado", "Codigo hexadecimal copiado al portapapeles.", "OK");
	}

	private void ActualizarColorYValores()
	{
		byte valorRojo = (byte)ColorRed.Value;
		byte valorVerde = (byte)ColorGreen.Value;
		byte valorAzul = (byte)ColorBlue.Value;

		PaginaHome.BackgroundColor = Color.FromRgb(valorRojo, valorVerde, valorAzul);

		EtiquetaValorRojo.Text = valorRojo.ToString();
		EtiquetaValorVerde.Text = valorVerde.ToString();
		EtiquetaValorAzul.Text = valorAzul.ToString();

		EtiquetaHexadecimal.Text = $"#{valorRojo:X2}{valorVerde:X2}{valorAzul:X2}";
	}
}
