using HomeAutomationMaui.Pages;

namespace HomeAutomationMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    async void Camera1Clicked(object sender, EventArgs e)
    {
        var navigationParameters = new Dictionary<string, object>()
        {
            {"TestKey", "TestValue" }
        };

        await Shell.Current.GoToAsync(nameof(Camera1), navigationParameters);
    }

    async void Camera2Clicked(object sender, EventArgs e)
    {
        var navigationParameters = new Dictionary<string, object>()
        {
            {"TestKey", "TestValue" }
        };

        await Shell.Current.GoToAsync(nameof(Camera2), navigationParameters);
    }


    async void SensorsClicked(object sender, EventArgs e)
    {
        var navigationParameters = new Dictionary<string, object>()
        {
            {"TestKey", "TestValue" }
        };

        await Shell.Current.GoToAsync(nameof(Sensors), navigationParameters);
    }
    async void AlarmsClicked(object sender, EventArgs e)
    {
        var navigationParameters = new Dictionary<string, object>()
        {
            {"TestKey", "TestValue" }
        };

        await Shell.Current.GoToAsync(nameof(Alarms), navigationParameters);
    }

    async void ServiceStateClicked(object sender, EventArgs e)
    {
        var navigationParameters = new Dictionary<string, object>()
        {
            {"TestKey", "TestValue" }
        };

        await Shell.Current.GoToAsync(nameof(ServicesState), navigationParameters);
    }
}

