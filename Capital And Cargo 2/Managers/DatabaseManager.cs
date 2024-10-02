using System.Diagnostics;
using CapitalAndCargo2.Interfaces;
using SQLite;

namespace CapitalAndCargo2.Managers;

internal class DatabaseManager : IDbManager, IDisposable
{
    public DatabaseManager() { }

    private DatabaseManager(SQLiteAsyncConnection connection)
    {
        _connection = connection;
    }

    private readonly SQLiteAsyncConnection _connection;
    private bool _disposed;

    /// <summary>
    /// Disposes this instance.
    /// </summary>
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _connection?.CloseAsync();
        }

        _disposed = true;
    }

    public IDbManager Initialize()
    {
        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "CapitalAndCargo", "CandC.db");
        if (!Directory.Exists(Path.GetDirectoryName(databasePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(databasePath));
        }

        if (!File.Exists(databasePath))
        {
            FileStream fs = File.Create(databasePath);
            fs.Close();
        }
#if DEBUG
        Debug.WriteLine("Database Path: " + databasePath);
#endif
        var connectionString = new SQLiteConnectionString(databasePath);
        var connection = new SQLiteAsyncConnection(connectionString);

        var dbManager = new DatabaseManager(connection);
        return dbManager;
    }

    public AsyncTableQuery<T> GetTable<T>() where T : class, IGameDataType, new()
    {
        return _connection.Table<T>();
    }

    public Task<T> Query<T>(string query)
    {
        return null;
    }

    public async Task<int> Insert<T>(T item)
    {
        return await _connection.InsertAsync(item);
    }

    public async Task<int> BulkInsert<T>(List<T> items)
    {
        return await _connection.InsertAllAsync(items);
    }

    public async Task<CreateTableResult> InitializeTable<T>() where T : class, IGameDataType, new()
    {
        return await _connection.CreateTableAsync<T>().ConfigureAwait(false);
    }
}