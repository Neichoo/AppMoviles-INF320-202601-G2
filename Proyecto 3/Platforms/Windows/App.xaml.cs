using Microsoft.UI.Xaml;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls;

namespace MiAppGastos;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
#pragma warning disable CA1416
public partial class App : MauiWinUIApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
#pragma warning restore CA1416

