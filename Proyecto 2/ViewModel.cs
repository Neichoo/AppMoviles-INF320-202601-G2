namespace MyTest;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class UserViewModel : ObservableObject
{
	// Total cuenta y por persona
	[ObservableProperty] private float amount;
	[ObservableProperty] private float total;
	// Propina porcentaje y decimal
	[ObservableProperty] private int tipPercentage;
	[ObservableProperty] private float tip;
	// Cantidad de personas
	[ObservableProperty] private int n;

    public UserViewModel()
    {
        //CalculateTotal();
    }
	/*
    // Cambio de valor
    partial void OnAmountChanged(float value) => CalculateTotal();
	// Cambio de porcentaje slider
    partial void OnTipPercentageChanged(int value) => CalculateTotal();
    partial void OnNChanged(int value) => CalculateTotal();
    

    // Comandos para los botones
    [RelayCommand]
    private void SetTip(int percentage)
    {
        //TipPercentage = percentage;
    }

    [RelayCommand]
    private void ChangePeopleCount(int amount)
    {
        
		
		N += amount;
		if(N < 1) N = 1;
		if(N > 4) N = 4;
		
    }

    // Lógica matemática
    private void CalculateTotal()
    {
        if (N <= 0) return;
		
        Tip = Amount * (float)(TipPercentage / 100);
        Total = (Amount + Tip) / N;
		
    }
	*/
}