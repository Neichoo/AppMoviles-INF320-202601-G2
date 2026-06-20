using MiAppGastos.Views;

namespace MiAppGastos;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(AddTransactionPage), typeof(AddTransactionPage));
    }
}