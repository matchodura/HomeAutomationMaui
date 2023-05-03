using HomeAutomationMaui.ViewModels;

namespace HomeAutomationMaui.Pages;

public partial class Rooms : ContentPage
{

    public Rooms(RoomsViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

}