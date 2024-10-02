using System.Text.Json;
using CapitalAndCargo2.Interfaces;
using CapitalAndCargo2.Models;
using CapitalAndCargo2.Models.GameData;
using CommunityToolkit.Mvvm.Messaging;
using SQLite;

namespace CapitalAndCargo2.Managers;

internal class CargoTypesManager(IDbManager databaseManager) : IManager, IRecipient<Message>
{
    private AsyncTableQuery<Cargo> _cargoData;

    public async Task Initialize()
    {
        var result = await databaseManager.InitializeTable<Cargo>().ConfigureAwait(false);
        if (await databaseManager.GetTable<Cargo>().CountAsync() == 0)
        {
            await using var stream = ResourcesManager.GetResourceStream("GameData_Cargo.json");
            var newCargoData = await JsonSerializer.DeserializeAsync<List<Cargo>>(stream ?? throw new InvalidOperationException());
            // TODO: Validate results
            // TODO: Validate newCargoData before insert
            var results = await databaseManager.BulkInsert(newCargoData);
        }
        _cargoData = databaseManager.GetTable<Cargo>();
    }

    public void Receive(Message message) { }
}