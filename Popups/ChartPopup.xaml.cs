using CommunityToolkit.Maui.Views;
using HomeAutomationMaui.ViewModels;
using LiveChartsCore.Defaults;

namespace HomeAutomationMaui.Popups;

public partial class ChartPopup : Popup
{
	public ChartPopup(List<DateTimePoint> dateTimePoints, string test)
	{
		InitializeComponent();
		//BindingContext = new ChartsViewModel(dateTimePoints, test);
		//BindingContext = new ChartsViewModel();
    }
}