using Microsoft.Data.SqlClient;

namespace DatabaseCleaner;

public class DatabaseCleanerBackgroundService : BackgroundService
{
    private readonly DatabaseCleanerService _databaseCleanerService;
    private readonly ILogger<DatabaseCleanerBackgroundService> _logger;

    public DatabaseCleanerBackgroundService(
        DatabaseCleanerService databaseCleanerService,
        ILogger<DatabaseCleanerBackgroundService> logger
    )
    {
        _databaseCleanerService = databaseCleanerService;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            var connectionString =
                "Server=.;Database=clinic-local;Encrypt=False;Trusted_Connection=True;";
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync(stoppingToken);
            _logger.LogWarning("{Now} - Connected to database", DateTime.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
                _logger.LogWarning("{Now} - Started cleaning", DateTime.Now);
                await _databaseCleanerService.RemoveLongDeletedEntitiesAsync(
                    connection,
                    stoppingToken
                );
                _logger.LogWarning("{Now} - Ended cleaning", DateTime.Now);
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("{Now} - Occured OperationCanceledException", DateTime.Now);
            Environment.Exit(0);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                "{Now} - Occured {Name}. Message: {Message}",
                DateTime.Now,
                exception.GetType().Name,
                exception.Message
            );
            Environment.Exit(1);
        }
    }
}
