using SQLite;

namespace CapitalAndCargo2.Interfaces;

internal interface IDbManager
{
    IDbManager Initialize();

    Task<CreateTableResult> InitializeTable<T>() where T : class, IGameDataType, new();

    AsyncTableQuery<T> GetTable<T>() where T : class, IGameDataType, new();

    Task<T> Query<T>(string query);

    Task<int> Insert<T>(T item);

    Task<int> BulkInsert<T>(List<T> items);
}