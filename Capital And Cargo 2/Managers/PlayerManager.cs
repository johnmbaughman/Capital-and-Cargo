using CapitalAndCargo2.Interfaces;
using CapitalAndCargo2.Models;
using CapitalAndCargo2.Models.GameData;
using CommunityToolkit.Mvvm.Messaging;
using SQLite;

namespace CapitalAndCargo2.Managers;

internal class PlayerManager(IDbManager databaseManager) : IManager, IRecipient<Message>
{
    private AsyncTableQuery<Player> _playerData;
    private AsyncTableQuery<MoneyHistory> _moneyHistoryData;
    private AsyncTableQuery<HistoryDetail> _historyData;
    private AsyncTableQuery<Warehouse> _warehouseData;

    public void Receive(Message message) { }

    public async Task Initialize()
    {
        var result = await databaseManager.InitializeTable<Player>().ConfigureAwait(false);
        _playerData = databaseManager.GetTable<Player>();

        result = await databaseManager.InitializeTable<MoneyHistory>().ConfigureAwait(false);
        _moneyHistoryData = databaseManager.GetTable<MoneyHistory>();

        result = await databaseManager.InitializeTable<HistoryDetail>().ConfigureAwait(false);
        _historyData = databaseManager.GetTable<HistoryDetail>();

        result = await databaseManager.InitializeTable<Warehouse>().ConfigureAwait(false);
        _warehouseData = databaseManager.GetTable<Warehouse>();
    }
}