namespace CalculadoraPropina;

using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public class CalculadoraPropinaViewModel : ObservableObject{
    private string totalConsumoTexto = string.Empty;
    private int cantidadPersonas = 1;
    private double porcentajePropina;
    private decimal subtotalPorPersona;
    private decimal propinaPorPersona;
    private decimal totalPorPersona;

    public CalculadoraPropinaViewModel(){
        SeleccionarPropinaCommand = new RelayCommand<int>(SeleccionarPropina);
        CambiarCantidadPersonasCommand = new RelayCommand<int>(CambiarCantidadPersonas);
        Recalcular();
    }

    public string TotalConsumoTexto{
        get => totalConsumoTexto;
        set{
            if (SetProperty(ref totalConsumoTexto, value)){
                Recalcular();
            }
        }
    }

    public int CantidadPersonas{
        get => cantidadPersonas;
        set{
            var valorNormalizado = value < 1 ? 1 : value;
            if (SetProperty(ref cantidadPersonas, valorNormalizado)){
                OnPropertyChanged(nameof(CantidadPersonasTexto));
                Recalcular();
            }
        }
    }

    public double PorcentajePropina{
        get => porcentajePropina;
        set{
            var valorNormalizado = value;
            if (valorNormalizado < 0){
                valorNormalizado = 0;
            }
            if (valorNormalizado > 50){
                valorNormalizado = 50;
            }
            if (SetProperty(ref porcentajePropina, valorNormalizado)){
                OnPropertyChanged(nameof(PorcentajePropinaTexto));
                Recalcular();
            }
        }
    }

    public decimal SubtotalPorPersona{
        get => subtotalPorPersona;
        private set{
            if (SetProperty(ref subtotalPorPersona, value)){
                OnPropertyChanged(nameof(SubtotalPorPersonaTexto));
            }
        }
    }

    public decimal PropinaPorPersona{
        get => propinaPorPersona;
        private set{
            if (SetProperty(ref propinaPorPersona, value)){
                OnPropertyChanged(nameof(PropinaPorPersonaTexto));
            }
        }
    }

    public decimal TotalPorPersona{
        get => totalPorPersona;
        private set{
            if (SetProperty(ref totalPorPersona, value)){
                OnPropertyChanged(nameof(TotalPorPersonaTexto));
            }
        }
    }

    public string CantidadPersonasTexto => CantidadPersonas.ToString();
    public string PorcentajePropinaTexto => $"{PorcentajePropina:0}%";
    public string SubtotalPorPersonaTexto => SubtotalPorPersona.ToString("N2", CultureInfo.CurrentCulture);
    public string PropinaPorPersonaTexto => PropinaPorPersona.ToString("N2", CultureInfo.CurrentCulture);
    public string TotalPorPersonaTexto => TotalPorPersona.ToString("N2", CultureInfo.CurrentCulture);
    public IRelayCommand<int> SeleccionarPropinaCommand { get; }
    public IRelayCommand<int> CambiarCantidadPersonasCommand { get; }

    private void SeleccionarPropina(int porcentaje){
        PorcentajePropina = porcentaje;
    }

    private void CambiarCantidadPersonas(int cambio){
        CantidadPersonas += cambio;
    }

    private void Recalcular(){
        var totalConsumo = ConvertirADecimal(TotalConsumoTexto);
        var factorPropina = (decimal)PorcentajePropina / 100m;

        SubtotalPorPersona = decimal.Round(totalConsumo / CantidadPersonas, 2);
        PropinaPorPersona = decimal.Round((totalConsumo * factorPropina) / CantidadPersonas, 2);
        TotalPorPersona = decimal.Round(SubtotalPorPersona + PropinaPorPersona, 2);
    }

    private static decimal ConvertirADecimal(string texto){
        if (string.IsNullOrWhiteSpace(texto)){
            return 0m;
        }
        if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out var valorLocal)){
            return valorLocal;
        }
        if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out var valorInvariante)){
            return valorInvariante;
        }
        return 0m;
    }
}
