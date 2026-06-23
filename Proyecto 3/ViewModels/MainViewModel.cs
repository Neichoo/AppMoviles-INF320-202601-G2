using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using MiAppGastos.Models;
using MiAppGastos.Services;

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
    }
    public async Task LoadTransactionsAsync()
    {
        var list = await _dbService.GetTransactionsAsync();
        Transactions = new ObservableCollection<Transaction>(list);
        CalculateTotals();
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
    // Usa nameof para evitar errores de escritura
    await Shell.Current.GoToAsync(nameof(Views.AddTransactionPage));
    }

    private void CalculateTotals()
    {
        TotalIngresos = Transactions.Where(t => t.Type == TransactionType.Ingreso).Sum(t => t.Amount);
        TotalGastos = Transactions.Where(t => t.Type == TransactionType.Gasto).Sum(t => t.Amount);
        TotalBalance = TotalIngresos - TotalGastos;
    }
}