using MiAppGastos.Models;
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

    private async void OnTransactionTapped(object? sender, EventArgs e)
    {
        if (sender is Border border && border.BindingContext is Transaction transaction)
        {
            await DisplayAlert("Detalle", transaction.Description, "Cerrar");
        }
    }
}