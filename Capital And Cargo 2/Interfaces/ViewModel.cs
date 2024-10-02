using CommunityToolkit.Mvvm.ComponentModel;

namespace CapitalAndCargo2.Interfaces;

internal abstract class ViewModel : ObservableObject, IViewModel
{
    public abstract Task Initialized();
}