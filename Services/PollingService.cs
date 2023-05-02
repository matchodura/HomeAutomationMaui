using HomeAutomationMaui.Models;
using PollingServiceClient;

namespace HomeAutomationMaui.Services
{
    public class PollingService
    {
        HttpClient httpClient;
        public PollingService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<SensorData>> GetDataAsync()
        {
            string baseUrl = "http://192.168.0.183:8080";
                       
            var serviceClient = new Client(baseUrl, httpClient);

            var results = new List<SensorData>();
            try
            {
                var data = await serviceClient.PollingAllAsync("1");

                foreach (var result in data)
                {

                    //todo look at this, as it doesn't seem to work correctly
                    var time = result.TimeOfMeasurement;

                    TimeZoneInfo systemTimeZone = TimeZoneInfo.Local;
                    DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(time, systemTimeZone);

                    //TODO: add automapper for this
                    results.Add(new SensorData()
                    {
                        SensorName = result.Sensor_name,
                        Location = result.Location,
                        Humidity = result.Humidity,
                        Temperature = result.Temperature,
                        TimeOfMeasurement = result.TimeOfMeasurement
                        //TimeOfMeasurement = localDateTime.ToString("yyyy/MM/dd/HH:mm:ss")
                    }); 
                }


            }
            catch (Exception ex) { }



  
            return results;
        }
    }
}
