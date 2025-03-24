using Godot;

public partial class GameManager : Node3D
{
    [Export]
    private Menu _pauseMenu;

    public override void _Ready()
    {
        _pauseMenu.GetNode<Button>("Exit").Pressed += OnExitPressed;
        _pauseMenu.GetNode<Button>("Continue").Pressed += TooglePause;
    }

    public void TooglePause()
    {
        GetTree().Paused = !GetTree().Paused;
        if (GetTree().Paused)
        {
            _pauseMenu.Open();
        }
        else
        {
            _pauseMenu.Close();
        }
    }

    private void OnExitPressed()
    {
        GD.Print("Exit pressed");
    }
}
