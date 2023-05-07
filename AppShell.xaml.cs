using HomeAutomationMaui.Pages;

namespace HomeAutomationMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Camera1), typeof(Camera1));
        Routing.RegisterRoute(nameof(Camera2), typeof(Camera2));
        Routing.RegisterRoute(nameof(Sensors), typeof(Sensors));
        Routing.RegisterRoute(nameof(ChartPage), typeof(ChartPage));
    }
}
