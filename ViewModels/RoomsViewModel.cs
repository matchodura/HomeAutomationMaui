﻿using CommunityToolkit.Mvvm.Input;
using HomeAutomationMaui.Interfaces;
using HomeAutomationMaui.Models;
using HomeAutomationMaui.Pages;
using HomeAutomationMaui.Services;
using LiveChartsCore.Defaults;
using System.Collections.ObjectModel;

namespace HomeAutomationMaui.ViewModels
{
    public partial class RoomsViewModel : BaseViewModel
    {
        public ObservableCollection<SensorData> Sensors { get; } = new();
        public ObservableCollection<SensorData> SensorValues { get; } = new();

        PollingService _pollingService;
        private readonly IPopupService _popupService;

        public SensorData SelectedSensor { get; set; }

        public RoomsViewModel(PollingService pollingService, IPopupService popupService)
        {
            Title = "Room Data";
            _pollingService = pollingService;
            _popupService = popupService;          
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
        public async Task SelectionChanged()
        {
            //SelectedSensor = Sensors.FirstOrDefault();

            var result = FilterChartValues();
            //var chartPopup = new ChartPopup(result,"XD");

            // _popupService.ShowPopup(chartPopup);

            var navigationParameters = new Dictionary<string, object>()
                                        {
                                            {"TemperatureData", result[0] },
                                            {"HumidityData", result[1] }

                                        };

            try
            {
                await Shell.Current.GoToAsync(nameof(ChartPage), navigationParameters);

            }
            catch (Exception ex) { }
        }

        private List<List<DateTimePoint>> FilterChartValues()
        {

            var sensorToCheck = SelectedSensor.Location;

            var valuesToCheck = SensorValues.Where(x => x.Location == sensorToCheck).ToList();


            var temperaturePoints = new List<DateTimePoint>();
            var humidityPoints = new List<DateTimePoint>();
            foreach (var res in valuesToCheck)
            {
                temperaturePoints.Add(new DateTimePoint(res.TimeOfMeasurement, res.Temperature));
                humidityPoints.Add(new DateTimePoint(res.TimeOfMeasurement, res.Humidity));
            }

            var results = new List<List<DateTimePoint>>() { temperaturePoints, humidityPoints };    

            return results;
        }
    }
}
