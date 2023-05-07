namespace HomeAutomationMaui.Converters
{
    public class ValueToVisibilityConverter : IValueConverter
    { 

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
            {
                if (System.Convert.ToDouble(value) < 1)
                    return false;
                else
                    return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }      
    }
}
