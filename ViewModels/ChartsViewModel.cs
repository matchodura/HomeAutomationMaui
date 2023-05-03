using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;

namespace HomeAutomationMaui.ViewModels
{
    public partial class ChartsViewModel : BaseViewModel, IQueryAttributable
    {
        public List<DateTimePoint> TemperaturePoints { get; private set; }
        public List<DateTimePoint> HumidityPoints { get; private set; }

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



        public ChartsViewModel()
        {     
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            TemperaturePoints = query["TemperatureData"] as List<DateTimePoint>;
            HumidityPoints = query["HumidityData"] as List<DateTimePoint>;

            TemperatureSeries[0].Values = TemperaturePoints;
            HumiditySeries[0].Values = HumidityPoints;
        }


        public Axis[] XAxes { get; set; } =
              {
                    new Axis
                    {
                        Labeler = value => new DateTime((long) value).ToString("yyyy/MM/dd/HH:mm:ss"),
                        LabelsRotation = 80,

                        // when using a date time type, let the library know your unit 
                        UnitWidth = TimeSpan.FromMinutes(1).Ticks, 

                        // if the difference between our points is in hours then we would:
                        // UnitWidth = TimeSpan.FromHours(1).Ticks,

                        // since all the months and years have a different number of days
                        // we can use the average, it would not cause any visible error in the user interface
                        // Months: TimeSpan.FromDays(30.4375).Ticks
                        // Years: TimeSpan.FromDays(365.25).Ticks

                        // The MinStep property forces the separator to be greater than 1 day.
                        MinStep = TimeSpan.FromMinutes(1).Ticks
                    }
                };



    }
}

