using Microsoft.Data.SqlClient;

namespace DatabaseCleaner;

public class DatabaseCleanerService
{
    private readonly ILogger<DatabaseCleanerService> _logger;

    public DatabaseCleanerService(ILogger<DatabaseCleanerService> logger)
    {
        _logger = logger;
    }

    public async Task RemoveLongDeletedEntitiesAsync(
        SqlConnection connection,
        CancellationToken cancellationToken = default
    )
    {
        var command = new SqlCommand();
        command.Connection = connection;

        command.CommandText = """
            DELETE FROM dbo.Accounts 
            WHERE IsDeleted = 1 AND DATEDIFF(DAY, DeletedTime, GETDATE()) >= 10
            """;
        var amountOfDeletedAccounts = await command.ExecuteNonQueryAsync(cancellationToken);
        _logger.LogWarning(
            "{Now} - Deleted {amountOfDeletedAccounts} records from 'dbo.Accounts'",
            DateTime.Now,
            amountOfDeletedAccounts
        );

        command.CommandText = """
            DELETE FROM dbo.Appointments 
            WHERE IsDeleted = 1 AND DATEDIFF(DAY, DeletedTime, GETDATE()) >= 10
            """;
        var amountOfDeletedAppointments = await command.ExecuteNonQueryAsync(cancellationToken);
        _logger.LogWarning(
            "{Now} - Deleted {amountOfDeletedAppointments} records from 'dbo.Appointments'",
            DateTime.Now,
            amountOfDeletedAppointments
        );

        command.CommandText = """
            DELETE FROM dbo.Doctors 
            WHERE IsDeleted = 1 AND DATEDIFF(DAY, DeletedTime, GETDATE()) >= 10
            """;
        var amountOfDeletedDoctors = await command.ExecuteNonQueryAsync(cancellationToken);
        _logger.LogWarning(
            "{Now} - Deleted {amountOfDeletedDoctors} records from 'dbo.Doctors'",
            DateTime.Now,
            amountOfDeletedDoctors
        );

        command.CommandText = """
            DELETE FROM dbo.Offices 
            WHERE IsDeleted = 1 AND DATEDIFF(DAY, DeletedTime, GETDATE()) >= 10
            """;
        var amountOfDeletedOffices = await command.ExecuteNonQueryAsync(cancellationToken);
        _logger.LogWarning(
            "{Now} - Deleted {amountOfDeletedOffices} records from 'dbo.Offices'",
            DateTime.Now,
            amountOfDeletedOffices
        );

        command.CommandText = """
            DELETE FROM dbo.Patients 
            WHERE IsDeleted = 1 AND DATEDIFF(DAY, DeletedTime, GETDATE()) >= 10
            """;
        var amountOfDeletedPatients = await command.ExecuteNonQueryAsync(cancellationToken);
        _logger.LogWarning(
            "{Now} - Deleted {amountOfDeletedPatients} records from 'dbo.Patients'",
            DateTime.Now,
            amountOfDeletedPatients
        );

        command.CommandText = """
            DELETE FROM dbo.Photos 
            WHERE IsDeleted = 1 AND DATEDIFF(DAY, DeletedTime, GETDATE()) >= 10
            """;
        var amountOfDeletedPhotos = await command.ExecuteNonQueryAsync(cancellationToken);
        _logger.LogWarning(
            "{Now} - Deleted {amountOfDeletedPhotos} from 'dbo.Photos'",
            DateTime.Now,
            amountOfDeletedPhotos
        );

        command.CommandText = """
            DELETE FROM dbo.Receptionists 
            WHERE IsDeleted = 1 AND DATEDIFF(DAY, DeletedTime, GETDATE()) >= 10
            """;
        var amountOfDeletedReceptionists = await command.ExecuteNonQueryAsync(cancellationToken);
        _logger.LogWarning(
            "{Now} - Deleted {amountOfDeletedReceptionists} records from 'dbo.Receptionists'",
            DateTime.Now,
            amountOfDeletedReceptionists
        );
    }
}
