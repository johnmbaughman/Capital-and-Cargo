namespace CapitalAndCargo2.Interfaces;

internal interface IView
{
    void InitializeComponent();

    IViewModel ViewModel { get; }
}