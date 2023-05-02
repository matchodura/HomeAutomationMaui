using HomeAutomationMaui.ViewModels;
using LiveChartsCore.Defaults;
using PollingServiceClient;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace HomeAutomationMaui.Pages;

public partial class Rooms : ContentPage
{

    public Rooms(RoomsViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

}