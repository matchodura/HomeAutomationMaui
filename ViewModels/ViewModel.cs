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
                // Use the ObservableValue or ObservablePoint types to let the chart listen for property changes // mark
                // or use any INotifyPropertyChanged implementation // mark
                //new ObservableValue(2),
                //new(5), // the ObservableValue type is redundant and inferred by the compiler (C# 9 and above)
                //new(4),
                //new(5),
                //new(2),
                //new(6),
                //new(6),
                //new(6),
                //new(4),
                //new(2),
                //new(3),
                //new(4),
                //new(3)
            };

            Series = new ObservableCollection<ISeries>
            {
                new LineSeries<ObservableValue>
                {
                    Values = _observableValues,
                    Fill = null
                }
            };

            // in the following sample notice that the type int does not implement INotifyPropertyChanged
            // and our Series.Values property is of type List<T>
            // List<T> does not implement INotifyCollectionChanged
            // this means the following series is not listening for changes.
            // Series.Add(new ColumnSeries<int> { Values = new List<int> { 2, 4, 6, 1, 7, -2 } }); // mark
        }

        public ObservableCollection<ISeries> Series { get; set; }

        public void SetValues(List<DateTimePoint> dateTimePoints)
        {
            Series.Add(new LineSeries<DateTimePoint>() { Values = dateTimePoints });
        }
    }
}

