using HomeAutomationMaui.ViewModels;

namespace HomeAutomationMaui.Pages;

public partial class ServicesState : ContentPage
{
	public ServicesState(ServicesStateViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}