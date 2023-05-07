using HomeAutomationMaui.ViewModels;

namespace HomeAutomationMaui.Pages;

public partial class Sensors : ContentPage
{

    public Sensors(SensorsViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

}