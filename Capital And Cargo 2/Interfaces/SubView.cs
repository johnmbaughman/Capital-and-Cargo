using Terminal.Gui;

namespace CapitalAndCargo2.Interfaces;

internal abstract class SubView(IViewModel viewModel) : View, IView
{
    public abstract void InitializeComponent();

    public IViewModel ViewModel { get; } = viewModel;
}