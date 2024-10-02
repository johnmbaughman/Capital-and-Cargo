using System.Globalization;
using CapitalAndCargo2.Interfaces;
using CapitalAndCargo2.Models;
using CommunityToolkit.Mvvm.Messaging;

namespace CapitalAndCargo2.Managers;

internal class GameDataManager(
    IDbManager databaseManager,
    PlayerManager playerManager,
    SoundManager soundManager,
    AchievementManager achievementManager,
    CitiesManager citiesManager,
    CargoTypesManager cargoTypesManager,
    FactoryManager factoryManager,
    TransitManager transitManager) : IManager, IRecipient<Message>
{
    private string _reputationCalculation = string.Empty;
    private readonly CargoTypesManager _cargoTypesManager = cargoTypesManager;
    private readonly CitiesManager _citiesManager = citiesManager;
    private readonly FactoryManager _factoryManager = factoryManager;
    private readonly TransitManager _transitManager = transitManager;
    private readonly PlayerManager _playerManager = playerManager;
    private readonly AchievementManager _achievementManager = achievementManager;
    private static double _buyReputation = .10;
    private static double _sellReputation = .15;
    private static double _importReputation = .50;
    private static double _exportReputation = .25;

    public async Task Initialize()
    {
        _reputationCalculation = $"(Bought * {_buyReputation.ToString(CultureInfo.InvariantCulture)}) + (Sold * {_sellReputation.ToString(CultureInfo.InvariantCulture)}) + (Imported * {_importReputation.ToString(CultureInfo.InvariantCulture)}) + (Exported * {_exportReputation.ToString(CultureInfo.InvariantCulture)})";
        await _cargoTypesManager.Initialize().ConfigureAwait(false);
        await _citiesManager.Initialize().ConfigureAwait(false);
        await _factoryManager.Initialize().ConfigureAwait(false);
        await _transitManager.Initialize().ConfigureAwait(false);
        await _playerManager.Initialize().ConfigureAwait(false);
        await _achievementManager.Initialize().ConfigureAwait(false);
    }

    public void Receive(Message message) { }
}