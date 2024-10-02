using Terminal.Gui;

namespace CapitalAndCargo2.Interfaces;

internal abstract class WindowView(IViewModel viewModel) : Window, IView
{
    public abstract void InitializeComponent();

    public IViewModel ViewModel { get; } = viewModel;
}