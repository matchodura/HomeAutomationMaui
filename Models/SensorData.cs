namespace HomeAutomationMaui.Models
{
    public class SensorData
    {
        public string SensorName { get; set; }
        public string Location { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime TimeOfMeasurement { get; set; }
        public string TimeOfMeasurementAsString { get; set; }

    }
}
