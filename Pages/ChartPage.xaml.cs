using HomeAutomationMaui.ViewModels;

namespace HomeAutomationMaui.Pages;

public partial class ChartPage : ContentPage
{
    public ChartPage(ChartsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }   
}