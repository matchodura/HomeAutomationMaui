using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace HomeAutomationMaui.ViewModels
{
    public class ViewModel
    {
        private readonly Random _random = new();
        private readonly ObservableCollection<ObservableValue> _observableValues;

        public ViewModel()
        {
            // Use ObservableCollections to let the chart listen for changes (or any INotifyCollectionChanged). // mark
            _observableValues = new ObservableCollection<ObservableValue>
            {
            };

            Series = new ObservableCollection<ISeries>
            {
                new LineSeries<ObservableValue>
                {
                    Values = _observableValues,
                    Fill = null
                }
            };
        }

        public ObservableCollection<ISeries> Series { get; set; }

        public void SetValues(List<DateTimePoint> dateTimePoints)
        {
            Series.Add(new LineSeries<DateTimePoint>() { Values = dateTimePoints });
        }
    }
}

