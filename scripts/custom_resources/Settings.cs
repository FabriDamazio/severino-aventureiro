using Godot;

[GlobalClass]
public partial class Settings : Resource
{
    [Export]
    public bool CameraInvertX { get; set; }

    [Export]
    public bool CameraInvertY { get; set; }

    [Export]
    public float Volume { get; set; }

    public Settings()
    {
        CameraInvertX = false;
        CameraInvertY = true;
        Volume = 0.5f;
    }
}
