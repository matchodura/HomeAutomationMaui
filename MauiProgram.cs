﻿using CommunityToolkit.Maui;
using HomeAutomationMaui.Interfaces;
using HomeAutomationMaui.Pages;
using HomeAutomationMaui.Services;
using HomeAutomationMaui.ViewModels;
using Plugin.LocalNotification;
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
			.UseMauiCommunityToolkit()
			.UseLocalNotification()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<Camera1>();
        builder.Services.AddTransient<Camera2>();
        builder.Services.AddTransient<Sensors>();
        builder.Services.AddTransient<ChartPage>();
        builder.Services.AddTransient<IPopupService, PopupService>();
		builder.Services.AddSingleton<PollingService>();
		builder.Services.AddSingleton<SensorsViewModel>();
		builder.Services.AddTransient<ChartsViewModel>();
		builder.Services.AddTransient<Alarms>();
		builder.Services.AddTransient<AlarmsViewModel>();
		builder.Services.AddTransient<ServicesState>();
		builder.Services.AddTransient<ServicesStateViewModel>();



        return builder.Build();
	}
}
