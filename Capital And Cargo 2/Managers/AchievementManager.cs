using CapitalAndCargo2.Interfaces;
using CapitalAndCargo2.Models;
using CapitalAndCargo2.Models.GameData;
using CommunityToolkit.Mvvm.Messaging;
using SQLite;

namespace CapitalAndCargo2.Managers;

internal class AchievementManager(IDbManager databaseManager) : IManager, IRecipient<Message>
{
    private AsyncTableQuery<Achievement> _achievementData;

    public void Receive(Message message)
    {
    }

    public async Task Initialize()
    {
        var result = await databaseManager.InitializeTable<Achievement>().ConfigureAwait(false);
        _achievementData = databaseManager.GetTable<Achievement>();
    }
}