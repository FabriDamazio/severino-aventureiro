using Godot;

public partial class File : Node
{
    [Export]
    public Settings Settings { get; set; }

    [Export]
    public Progress Progress { get; set; }

    public override void _Ready()
    {
        Settings = new Settings();
        Progress = new Progress();
    }
}
