using CommunityToolkit.Mvvm.Input;
using HomeAutomationMaui.Models;
using HomeAutomationMaui.Services;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System.Collections.ObjectModel;
using PollingServiceClient;

namespace HomeAutomationMaui.ViewModels
{
    public partial class RoomsViewModel : BaseViewModel
    {
        public ObservableCollection<SensorData> Sensors { get; } = new();
        public ObservableCollection<SensorData> SensorValues { get; } = new();

        PollingService _pollingService;

        public SensorData SelectedSensor { get; set; }

        public ObservableCollection<ISeries> Series { get; set; } = new();

        public void SetChartValues(List<DateTimePoint> dateTimePoints)
        {
            Series.Add(new LineSeries<DateTimePoint>() { Values = dateTimePoints });
        }



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

                foreach(var result in results)
                {
                    SensorValues.Add(result);
                }


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


        [RelayCommand]
        public void SelectionChanged()
        {
            SelectedSensor = Sensors.FirstOrDefault();

            var result = FilterChartValues();

            SetChartValues(result);

        }

        private List<DateTimePoint> FilterChartValues()
        {

            var sensorToCheck = SelectedSensor.SensorName;

            var valuesToCheck = SensorValues.Where(x=>x.SensorName == sensorToCheck).ToList();

            var results = new List<DateTimePoint>();
            foreach (var res in valuesToCheck)
            {
                results.Add(new DateTimePoint(Convert.ToDateTime(res.TimeOfMeasurement), res.Temperature));
            }

            return results;
        }
    }
}
