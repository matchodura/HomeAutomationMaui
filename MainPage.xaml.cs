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
}

