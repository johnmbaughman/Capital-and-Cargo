using CapitalAndCargo2.Interfaces;
using CapitalAndCargo2.Models;
using CommunityToolkit.Mvvm.Messaging;

namespace CapitalAndCargo2.Managers;

internal class SoundManager : IManager, IRecipient<Message>
{
    public void Receive(Message message) { }
    public Task Initialize() => throw new NotImplementedException();
}