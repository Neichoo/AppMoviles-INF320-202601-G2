using AndroidX.Lifecycle;

namespace MyTest;

public partial class MainPage : ContentPage
{

	private UserViewModel viewModel;

	public MainPage()
	{
		InitializeComponent();
		viewModel = new UserViewModel();
		BindingContext = viewModel;
	}
}
