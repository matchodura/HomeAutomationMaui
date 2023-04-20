using HomeAutomationMaui.Pages;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace HomeAutomationMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseSkiaSharp()
			.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<Camera1>();
        builder.Services.AddTransient<Camera2>();

        return builder.Build();
	}
}
