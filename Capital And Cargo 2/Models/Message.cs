using NLog.LayoutRenderers.Wrappers;

namespace CapitalAndCargo2.Models;

internal class Message
{
    public MessageType Type { get; set; }

    public object? Value { get; set; }
}

internal enum MessageType {
    MainViewLoaded
}