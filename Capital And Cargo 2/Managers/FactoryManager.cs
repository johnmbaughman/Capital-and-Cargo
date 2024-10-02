using CapitalAndCargo2.Interfaces;
using CapitalAndCargo2.Models;
using CapitalAndCargo2.Models.GameData;
using CommunityToolkit.Mvvm.Messaging;
using SQLite;

namespace CapitalAndCargo2.Managers;

internal class FactoryManager(IDbManager databaseManager) : IManager, IRecipient<Message>
{
    private AsyncTableQuery<Factory> _factoryData;

    public void Receive(Message message) { }

    public async Task Initialize()
    {
        var result = await databaseManager.InitializeTable<Factory>().ConfigureAwait(false);
        _factoryData = databaseManager.GetTable<Factory>();
    }
}