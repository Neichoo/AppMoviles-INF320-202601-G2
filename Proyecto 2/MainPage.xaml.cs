namespace CalculadoraPropina;

public partial class MainPage : ContentPage
{
    public MainPage(){
        InitializeComponent();
        BindingContext = new CalculadoraPropinaViewModel();
    }
}
