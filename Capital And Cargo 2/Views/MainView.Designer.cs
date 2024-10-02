using CapitalAndCargo2.Managers;
using CapitalAndCargo2.Models;
using CommunityToolkit.Mvvm.Messaging;
using Terminal.Gui;

namespace CapitalAndCargo2.Views;

internal partial class MainView
{
    private MenuBar menuBar;
    private FrameView topContainer;
    private View titleContainer;
    private View mainContainer;
    private Label dateField;
    private Label achievementsField;
    private Label moneyField;
    private Button fastForwardButton;
    private Button normalSpeedButton;
    private Button pauseButton;
    private View leftColumn;
    private View rightColumn;

    public sealed override void InitializeComponent()
    {
        menuBar = new MenuBar();
        menuBar.Menus = new MenuBarItem[] {
            new MenuBarItem("_File", new MenuItem[]
        {
            new MenuItem("_Quit", "", () => { Application.RequestStop(); }),
            //TODO: Fill in the remaining menu items
            new MenuItem("_Settings", "", () => {  })
        }) };
        Add(menuBar);

        topContainer = new FrameView();
        topContainer.X = 0;
        topContainer.Y = 1; // Offset by 1 due to the menu bar
        topContainer.Width = Dim.Fill();
        topContainer.Height = Dim.Fill() - 1; // Account for the menu bar
        topContainer.Title = " Capital & Cargo";
        Add(topContainer);

        titleContainer = new View();
        titleContainer.X = 0;
        titleContainer.Y = 0; // Offset by 1 due to the menu bar
        titleContainer.Width = Dim.Fill();
        titleContainer.Height = 1; // Account for the menu bar

        dateField = new Label();
        dateField.X = 1;
        dateField.Y = 0;
        dateField.Text = "Jan 1 1900";
        titleContainer.Add(dateField);

        achievementsField = new Label();
        achievementsField.X = Pos.Percent(50) - 12;
        achievementsField.Y = 0;
        achievementsField.Text = "";
        titleContainer.Add(achievementsField);

        moneyField = new Terminal.Gui.Label()
        {
            X = Pos.Percent(50),
            Y = 0,
            Text = "€ 0.000.000.000"
        };
        fastForwardButton = new Button();
        fastForwardButton.X = Pos.Percent(75);
        fastForwardButton.Y = 0;
        fastForwardButton.Text = ">>";
        fastForwardButton.ColorScheme = ResourcesManager.EnabledColorScheme;
        titleContainer.Add(fastForwardButton);

        normalSpeedButton = new Button();
        normalSpeedButton.X = Pos.Percent(70);
        normalSpeedButton.Y = 0;
        normalSpeedButton.Text = ">";
        normalSpeedButton.ColorScheme = ResourcesManager.EnabledColorScheme;
        titleContainer.Add(normalSpeedButton);

        pauseButton = new Button();
        pauseButton.X = Pos.Percent(81);
        pauseButton.Y = 0;
        pauseButton.Text = "||";
        pauseButton.ColorScheme = ResourcesManager.EnabledColorScheme;
        titleContainer.Add(pauseButton);

        topContainer.Add(titleContainer);

        mainContainer = new View();
        mainContainer.X = 0;
        mainContainer.Y = 1; // Offset by 1 due to the menu bar
        mainContainer.Width = Dim.Fill();
        mainContainer.Height = Dim.Fill() - 1; // Account for the menu bar

        leftColumn = new View();
        leftColumn.X = 0;
        leftColumn.Y = 0;
        Width = Dim.Percent(50);
        Height = Dim.Fill();
        mainContainer.Add(leftColumn);

        rightColumn = new View();
        rightColumn.X = Pos.Right(leftColumn);
        rightColumn.Y = 0;
        Width = Dim.Fill();
        Height = Dim.Fill();
        mainContainer.Add(rightColumn);

        var message = new Message() { Type = MessageType.MainViewLoaded, Value = this };
        WeakReferenceMessenger.Default.Send(message);
    }

    public void AddLeftView(View subview)
    {
        leftColumn.Add(subview);
    }

    public void AddRightView(View subview)
    {
        rightColumn.Add(subview);
    }
}