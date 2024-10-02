using CapitalAndCargo2.Interfaces;
using CapitalAndCargo2.Models;
using CapitalAndCargo2.Models.GameData;
using CapitalAndCargo2.Views;
using CommunityToolkit.Mvvm.Messaging;
using SQLite;

namespace CapitalAndCargo2.Managers;

internal class TransitManager(IDbManager databaseManager, TransitView transitView) : IManager, IRecipient<Message>
{
    private AsyncTableQuery<CityTransit> _factoryData;

    public void Receive(Message message) { }

    public async Task Initialize()
    {
        var result = await databaseManager.InitializeTable<CityTransit>().ConfigureAwait(false);
        _factoryData = databaseManager.GetTable<CityTransit>();
    }
}