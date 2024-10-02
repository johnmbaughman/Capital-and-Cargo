using CapitalAndCargo2.Interfaces;
using CapitalAndCargo2.Models;
using CapitalAndCargo2.ViewModels;
using CommunityToolkit.Mvvm.Messaging;

namespace CapitalAndCargo2.Views;

internal partial class CitiesView : SubView, IRecipient<Message>
{
    public CitiesView(CitiesViewModel viewModel) : base(viewModel)
    {
        WeakReferenceMessenger.Default.Register(this);
        InitializeComponent();
    }

    public void Receive(Message message)
    {
        switch (message.Type)
        {
            case MessageType.MainViewLoaded:
 //               ((MainView)message.Value).AddLeftView(this);
                break;
        }
    }
}