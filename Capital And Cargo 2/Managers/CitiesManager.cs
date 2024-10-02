using System.Text.Json;
using CapitalAndCargo2.Interfaces;
using CapitalAndCargo2.Models;
using CapitalAndCargo2.Models.GameData;
using CapitalAndCargo2.Views;
using CommunityToolkit.Mvvm.Messaging;
using SQLite;

namespace CapitalAndCargo2.Managers;

internal class CitiesManager(IDbManager databaseManager, CitiesView citiesView) : IManager, IRecipient<Message>
{
    private AsyncTableQuery<City> _cityData;

    public void Receive(Message message)
    {
    }

    public async Task Initialize()
    {
        var result = await databaseManager.InitializeTable<City>().ConfigureAwait(false);
        if (await databaseManager.GetTable<City>().CountAsync() == 0)
        {
            await using var stream = ResourcesManager.GetResourceStream("GameData_Cities.json");
            var newCityData = await JsonSerializer.DeserializeAsync<List<City>>(stream ?? throw new InvalidOperationException());
            // TODO: Validate results
            // TODO: Validate newCargoData before insert
            var results = await databaseManager.BulkInsert(newCityData);
        }
        _cityData = databaseManager.GetTable<City>();
    }
}