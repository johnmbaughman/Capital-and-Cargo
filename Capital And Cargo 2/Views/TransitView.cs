using CapitalAndCargo2.Interfaces;
using CapitalAndCargo2.Models;
using CapitalAndCargo2.ViewModels;
using CommunityToolkit.Mvvm.Messaging;

namespace CapitalAndCargo2.Views;

internal partial class TransitView : SubView, IRecipient<Message>
{
    public TransitView(TransitViewModel viewModel) : base(viewModel)
    {
        WeakReferenceMessenger.Default.Register(this);
        InitializeComponent();
    }

    public void Receive(Message message) { }
}