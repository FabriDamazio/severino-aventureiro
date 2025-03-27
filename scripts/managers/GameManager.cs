using Godot;

public partial class GameManager : SceneManager
{
    [Export]
    private Menu _pauseMenu;

    private Music _music;

    public override void _Ready()
    {
        base._Ready();

        _music = GetNode<Music>("/root/Music");

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

    private async void OnExitPressed()
    {
        _music.FadeOut();
        await _fade.ToBlack();
        GetTree().Paused = false;
        GetTree().ChangeSceneToFile("res://scenes/title.tscn");
    }
}
