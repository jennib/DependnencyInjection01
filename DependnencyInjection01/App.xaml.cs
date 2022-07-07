using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace DependnencyInjection01;

public partial class App : Application
{
    private readonly IHost _host;
    
    public App()
    {
        // Create the Service and tell it to use ConfigureServices method.
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                ConfigureServices(services);
            })
            .Build();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Start the services.
        services.AddSingleton<MainWindow>();
        services.AddTransient<IDateTimeService, DateTimeService>();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        // Startup the Host.
        await _host.StopAsync();
        
        // Start the MainWindow that we added as a singleton service.
        var mainWindows = _host.Services.GetRequiredService<MainWindow>();
        mainWindows.Show();
        
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        // Shut down the Host.
        using (_host)
        {
            await _host.StopAsync();
        }
        
        base.OnExit(e);
    }
}

