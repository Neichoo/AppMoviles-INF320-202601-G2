using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MiAppGastos.Models;
using MiAppGastos.Services;
using Microsoft.Maui.Controls;

namespace MiAppGastos.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IDatabaseService _dbService;

    [ObservableProperty]
    private ObservableCollection<Transaction> transactions = new();

    [ObservableProperty]
    private decimal totalBalance;

    [ObservableProperty]
    private decimal totalIngresos;

    [ObservableProperty]
    private decimal totalGastos;

    public MainViewModel(IDatabaseService dbService)
    {
        _dbService = dbService;
        // ✅ NO cargues datos aquí; la página llamará a LoadTransactionsAsync()
    }

    // ✅ Método público y con manejo de errores
    public async Task LoadTransactionsAsync()
    {
        try
        {
            var list = await _dbService.GetTransactionsAsync();
            Transactions = new ObservableCollection<Transaction>(list);
            CalculateTotals();
        }
        catch (System.Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Error al cargar: {ex.Message}", "OK");
        }
    }

    [RelayCommand]
    private async Task DeleteTransaction(int id)
    {
        await _dbService.DeleteTransactionAsync(id);
        await LoadTransactionsAsync();
    }

    [RelayCommand]
    private async Task GoToAddTransaction()
    {
        try
        {
            // Usa nameof para evitar errores de escritura
            await Shell.Current.GoToAsync(nameof(Views.AddTransactionPage));
        }
        catch
        {
            // Fallback: navegación alternativa (si es necesario)
            await Application.Current.MainPage.DisplayAlert("Error", "No se pudo navegar", "OK");
        }
    }

    private void CalculateTotals()
    {
        TotalIngresos = Transactions.Where(t => t.Type == TransactionType.Ingreso).Sum(t => t.Amount);
        TotalGastos = Transactions.Where(t => t.Type == TransactionType.Gasto).Sum(t => t.Amount);
        TotalBalance = TotalIngresos - TotalGastos;
    }
}