namespace MyTest;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class UserViewModel : ObservableObject
{
	[ObservableProperty] private string Total;
	[ObservableProperty] private string Tip;
	[ObservableProperty] private string N;

	public UserViewModel()
	{
		Total = "";
		Tip = "";
		N = "";
	}

	[RelayCommand]

	public void LoadUser()
	{
		Total = "$0";
		Tip = "0%";
		N = "1";
	}
}