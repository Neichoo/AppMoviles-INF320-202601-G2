using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiAppGastos.Models;
using MiAppGastos.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MiAppGastos.ViewModels;

public partial class AddTransactionViewModel : ObservableObject
{
    private readonly IDatabaseService _dbService;

    [ObservableProperty]
    private string description = string.Empty;

    [ObservableProperty]
    private decimal amount;

    [ObservableProperty]
    private DateTime date = DateTime.Today;

    [ObservableProperty]
    private TransactionType selectedType = TransactionType.Gasto;

    // Lista fija para el Picker
    public List<string> TipoOptions { get; } = new List<string> { "Gasto", "Ingreso" };

    private int selectedTipoIndex;
    public int SelectedTipoIndex
    {
        get => selectedTipoIndex;
        set
        {
            SetProperty(ref selectedTipoIndex, value);
            SelectedType = value == 0 ? TransactionType.Gasto : TransactionType.Ingreso;
        }
    }

    public AddTransactionViewModel(IDatabaseService dbService)
    {
        _dbService = dbService;
    }

    [RelayCommand]
    private async Task Save()
    {
        if (string.IsNullOrWhiteSpace(Description) || Amount <= 0)
        {
#pragma warning disable CS0618, CA1416, CS8602, IDE0270
            if (Application.Current?.Windows != null && Application.Current.Windows.Count > 0)
            {
                await Application.Current.Windows[0].Page?.DisplayAlert("Error", "Descripción y monto válido requeridos", "OK");
            }
#pragma warning restore CS0618, CA1416, CS8602, IDE0270
            return;
        }

        var transaction = new Transaction
        {
            Description = Description,
            Amount = Amount,
            Date = Date,
            Type = SelectedType
        };

        await _dbService.AddTransactionAsync(transaction);
#pragma warning disable CA1416
#if __IOS__ || __MACOS__
        await Shell.Current.GoToAsync("..");
#else
        try
        {
            if (Shell.Current != null)
                await Shell.Current.GoToAsync("..");
        }
        catch
        {
            // Fallback navigation
        }
#endif
#pragma warning restore CA1416
    }

    [RelayCommand]
    private async Task Cancel()
    {
#pragma warning disable CA1416
#if __IOS__ || __MACOS__
        await Shell.Current.GoToAsync("..");
#else
        try
        {
            if (Shell.Current != null)
                await Shell.Current.GoToAsync("..");
        }
        catch
        {
            // Fallback navigation
        }
#endif
#pragma warning restore CA1416
    }
}