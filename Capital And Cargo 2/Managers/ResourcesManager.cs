using Terminal.Gui;
using static System.Reflection.Assembly;

namespace CapitalAndCargo2.Managers;

public static class ResourcesManager
{
    public static Stream? GetResourceStream(string resourceName)
    {
        var info = GetExecutingAssembly().GetName();
        var stream = GetExecutingAssembly()
            .GetManifestResourceStream($"{info.Name}.Resources.{resourceName}");
        return stream;
    }

    public static ColorScheme EnabledColorScheme = new ColorScheme
    {
        Normal = Application.Driver.MakeColor(Color.Blue, Color.Black),
        Focus = Application.Driver.MakeColor(Color.Blue, Color.Black),
    };

    public static ColorScheme MyColorScheme = new ColorScheme
    {
        Normal = Application.Driver.MakeColor(Color.BrightGreen, Color.Black),
        Focus = Application.Driver.MakeColor(Color.Yellow, Color.Black)
    };
}