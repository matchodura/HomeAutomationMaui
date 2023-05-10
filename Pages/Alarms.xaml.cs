using HomeAutomationMaui.ViewModels;

namespace HomeAutomationMaui.Pages;

public partial class Alarms : ContentPage
{
	public Alarms(AlarmsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}