using CommunityToolkit.Mvvm.Input;
using HomeAutomationMaui.Models;
using HomeAutomationMaui.Services;
using System.Collections.ObjectModel;

namespace HomeAutomationMaui.ViewModels
{
    public partial class RoomsViewModel : BaseViewModel
    {
        public ObservableCollection<SensorData> Sensors { get; } = new();
        PollingService _pollingService;

        public RoomsViewModel(PollingService pollingService)
        {
            Title = "Room Data";
            _pollingService = pollingService;

        }

        [RelayCommand]
        public async Task GetSensorData()
        {
            if(IsBusy) return;

            try
            {
                IsBusy = true;

                //todo think about displaying last 5 measurements in UI
                var results = await _pollingService.GetDataAsync();

                var filteredResults = results.OrderByDescending(x => x.TimeOfMeasurement).DistinctBy(x => x.Location);



                foreach(var sensor in filteredResults)
                {
                    Sensors.Add(sensor);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
