using HomeAutomationMaui.ViewModels;
using LiveChartsCore.Defaults;
using PollingServiceClient;


namespace HomeAutomationMaui.Pages;

public partial class Measurements : ContentPage
{

	public Measurements()
	{
		InitializeComponent();
        var vm = (ViewModel)BindingContext;
        
        var result = Task.Run(async () => await GetDataAsync());

        vm.SetValues(result.Result);

    }

	public async Task<List<DateTimePoint>> GetDataAsync()
	{
        string baseUrl = "http://192.168.0.199:9245";

        var httpClient = new HttpClient();
        var serviceClient = new Client(baseUrl, httpClient);

        var results = new List<DateTimePoint>();
        try
        {


            var result = await serviceClient.PollingAllAsync("1");

          
            foreach (var res in result)
            {
                results.Add(new DateTimePoint(res.TimeOfMeasurement, res.Temperature));   
            }


        }
        catch (Exception ex) { }
        return results;
    }
}