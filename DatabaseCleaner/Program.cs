using DatabaseCleaner;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddWindowsService(options =>
        {
            options.ServiceName = "Database Cleaner Service";
        });
        builder.Services.AddScoped<DatabaseCleanerService>();
        builder.Services.AddHostedService<DatabaseCleanerBackgroundService>();

        var host = builder.Build();
        host.Run();
    }
}
