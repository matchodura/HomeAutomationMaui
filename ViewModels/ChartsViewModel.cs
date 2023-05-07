using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomeAutomationMaui.Models;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace HomeAutomationMaui.ViewModels
{
    public partial class ChartsViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        SensorData selectedSensor;

        public List<DateTimePoint> TemperaturePoints { get; private set; }
        public List<DateTimePoint> HumidityPoints { get; private set; }
        public List<DateTimePoint> PressurePoints { get; private set; }


        public ISeries[] TemperatureSeries { get; set; } =
        {
                new LineSeries<DateTimePoint>
                {
                    TooltipLabelFormatter = (chartPoint) =>
                        $"{new DateTime((long) chartPoint.SecondaryValue):dd/MM/HH:mm}: {Math.Round(chartPoint.PrimaryValue,2)}",

                    Values = new ObservableCollection<DateTimePoint> {  }
                }
        };

        public ISeries[] HumiditySeries { get; set; } =
        {
                new LineSeries<DateTimePoint>
                {
                    TooltipLabelFormatter = (chartPoint) =>
                        $"{new DateTime((long) chartPoint.SecondaryValue):dd/MM/HH:mm}: {Math.Round(chartPoint.PrimaryValue,2)}",

                    Values = new ObservableCollection<DateTimePoint> {  }
                }
        };

        public ISeries[] PressureSeries { get; set; } =
{
                new LineSeries<DateTimePoint>
                {
                    TooltipLabelFormatter = (chartPoint) =>
                        $"{new DateTime((long) chartPoint.SecondaryValue):dd/MM/HH:mm}: {Math.Round(chartPoint.PrimaryValue,2)}",

                    Values = new ObservableCollection<DateTimePoint> {  }
                }
        };


        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                Labeler = value => new DateTime((long) value).ToString("dd/MM/HH:mm"),
                LabelsRotation = 80
            }
        };


        public ChartsViewModel()
        {
            Title = "Charts Data";
        }


        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            TemperaturePoints = query["TemperatureData"] as List<DateTimePoint>;
            HumidityPoints = query["HumidityData"] as List<DateTimePoint>;
            PressurePoints = query["PressureData"] as List<DateTimePoint>;
            SelectedSensor = query["SelectedSensor"] as SensorData;

            TemperatureSeries[0].Values = TemperaturePoints;
            HumiditySeries[0].Values = HumidityPoints; 
            PressureSeries[0].Values = PressurePoints;                     
        }


        [RelayCommand]
        public void GoTo30days()
        {
            var axis = XAxes[0];
            var newestPoint = TemperatureSeries[0].Values.Cast<DateTimePoint>().FirstOrDefault().DateTime;
            var oldestPoint = newestPoint.AddDays(-30);

            axis.MinLimit = oldestPoint.Ticks;
            axis.MaxLimit = newestPoint.Ticks;
        
            axis.MinStep = TimeSpan.FromHours(1).Ticks;
            XAxes[0] = axis;
        }     
        
        [RelayCommand]
        public void GoTo7days()
        {
            var axis = XAxes[0];
            var newestPoint = TemperatureSeries[0].Values.Cast<DateTimePoint>().FirstOrDefault().DateTime;
            var oldestPoint = newestPoint.AddDays(-7);

            axis.MinLimit = oldestPoint.Ticks;
            axis.MaxLimit = newestPoint.Ticks;
          
            axis.MinStep = TimeSpan.FromHours(1).Ticks;
            XAxes[0] = axis;
        }

        [RelayCommand]
        public void GoTo3days()
        { 
            var axis = XAxes[0];
            var newestPoint = TemperatureSeries[0].Values.Cast<DateTimePoint>().FirstOrDefault().DateTime;
            var oldestPoint = newestPoint.AddDays(-3);           

            axis.MinLimit = oldestPoint.Ticks;
            axis.MaxLimit = newestPoint.Ticks;
            
            axis.MinStep = TimeSpan.FromHours(1).Ticks;
            XAxes[0] = axis;
        }

        [RelayCommand]
        public void GoTo1day()
        {
            var axis = XAxes[0];
            var newestPoint = TemperatureSeries[0].Values.Cast<DateTimePoint>().FirstOrDefault().DateTime;
            var oldestPoint = newestPoint.AddDays(-1);

            axis.MinLimit = oldestPoint.Ticks;
            axis.MaxLimit = newestPoint.Ticks;
      
            axis.MinStep = TimeSpan.FromHours(1).Ticks;
            XAxes[0] = axis;
        }

        [RelayCommand]
        public void GoTo12hours()
        {
            var axis = XAxes[0];
            var newestPoint = TemperatureSeries[0].Values.Cast<DateTimePoint>().FirstOrDefault().DateTime;
            var oldestPoint = newestPoint.AddHours(-12);

            axis.MinLimit = oldestPoint.Ticks;
            axis.MaxLimit = newestPoint.Ticks;
            axis.MinStep = TimeSpan.FromMinutes(30).Ticks;
            XAxes[0] = axis;
        }

        [RelayCommand]
        public void GoTo6hours()
        {
            var axis = XAxes[0];
            var newestPoint = TemperatureSeries[0].Values.Cast<DateTimePoint>().FirstOrDefault().DateTime;
            var oldestPoint = newestPoint.AddHours(-6);

            axis.MinLimit = oldestPoint.Ticks;
            axis.MaxLimit = newestPoint.Ticks;
            axis.MinStep = TimeSpan.FromMinutes(30).Ticks;
            XAxes[0] = axis;
        }

        [RelayCommand]
        public void GoTo3hours()
        {
            var axis = XAxes[0];
            var newestPoint = TemperatureSeries[0].Values.Cast<DateTimePoint>().FirstOrDefault().DateTime;
            var oldestPoint = newestPoint.AddHours(-3);

            axis.MinLimit = oldestPoint.Ticks;
            axis.MaxLimit = newestPoint.Ticks;
            axis.MinStep = TimeSpan.FromMinutes(30).Ticks;
            XAxes[0] = axis;
        }

        [RelayCommand]
        public void SeeAll()
        {
            var axis = XAxes[0];
            axis.MinLimit = null;
            axis.MaxLimit = null;

            XAxes[0] = axis;
        }
    }
}

