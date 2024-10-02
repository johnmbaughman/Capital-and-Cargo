using CapitalAndCargo2.Interfaces;
using CapitalAndCargo2.Managers;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CapitalAndCargo2.ViewModels;

internal class MainViewModel(GameDataManager gameDataManager) : ViewModel
{
    private readonly GameDataManager _gameDataManager = gameDataManager;

    public override async Task Initialized()
    {
        await _gameDataManager.Initialize().ConfigureAwait(false);
    }
}