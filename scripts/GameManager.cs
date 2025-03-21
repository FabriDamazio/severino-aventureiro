using Godot;

public partial class GameManager : Node3D
{
    public void TooglePause()
    {
        GD.Print(GetTree().Paused);
        GetTree().Paused = !GetTree().Paused;
    }
}
