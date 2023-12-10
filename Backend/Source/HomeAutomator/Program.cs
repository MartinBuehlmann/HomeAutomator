namespace HomeAutomator;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseSystemd()
            .ConfigureLogging(logging => logging
                .ClearProviders()
                .AddConsole())
            .ConfigureWebHostDefaults(webBuilder => webBuilder
                .UseKestrel()
                .UseUrls("http://*:5000")
                .UseStartup<Startup>());
    }
}