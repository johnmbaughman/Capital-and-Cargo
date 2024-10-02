using CapitalAndCargo2.Interfaces;
using CapitalAndCargo2.Models;
using CapitalAndCargo2.ViewModels;
using CommunityToolkit.Mvvm.Messaging;

namespace CapitalAndCargo2.Views;

internal partial class MainView : WindowView, IRecipient<Message>
{
    public MainView(MainViewModel viewModel) : base(viewModel)
    {
        WeakReferenceMessenger.Default.Register(this);
        InitializeComponent();
        Initialized += async (_, _) => await ViewModel.Initialized().ConfigureAwait(false);
    }

    public void Receive(Message message)
    {

    }
}