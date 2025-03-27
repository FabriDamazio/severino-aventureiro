using Godot;

public partial class SceneManager : Node
{
    [Export]
    protected Fade _fade;

    [Export]
    protected AudioStream _backgroundMusic;

    private Music _music;

    public override void _Ready()
    {
      _music = GetNode<Music>("/root/Music");
      _music.Play(_backgroundMusic);
      _fade.ToClear();
    }
}
