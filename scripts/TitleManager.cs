using Godot;

public partial class TitleManager : Node
{
    private Menu _menuButtons;

    public override void _Ready()
    {
        _menuButtons = GetNode<Menu>("%MenuButtons");
        _menuButtons.GetNode<Button>("NewGame").Pressed += OnNewGamePressed;
        _menuButtons.GetNode<Button>("Continue").Pressed += OnContinuePressed;
        _menuButtons.GetNode<Button>("Settings").Pressed += OnSettingsPressed;
        _menuButtons.GetNode<Button>("Credits").Pressed += OnCreditsPressed;
        _menuButtons.GetNode<Button>("Exit").Pressed += OnExitPressed;
        _menuButtons.Open();
    }

    private void OnNewGamePressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/game.tscn");
    }

    private void OnContinuePressed()
    {
        GD.Print("Continue pressed");
    }

    private void OnSettingsPressed()
    {
        GD.Print("Settings pressed");
    }

    private void OnCreditsPressed()
    {
        GD.Print("Credits pressed");
    }

    private void OnExitPressed()
    {
        GetTree().Quit();
    }
}
