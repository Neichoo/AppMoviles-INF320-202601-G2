using MiAppGastos.ViewModels;

namespace MiAppGastos.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Carga los datos cuando la página se muestra
        if (BindingContext is MainViewModel vm)
        {
            await vm.LoadTransactionsAsync();
        }
    }
}