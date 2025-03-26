using Godot;

public partial class SceneManager : Node
{
    [Export]
    protected Fade _fade;

    public override void _Ready()
    {
      _fade.ToClear();
    }
}
