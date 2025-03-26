using Godot;

public partial class SpringArm : SpringArm3D
{
    [Export]
    private float _rotationSpeed = 1.0f;

    [Export]
    private float _minXRotation = -Mathf.Pi / 3;

    [Export]
    private float _maxXRotation = 0f;

    private File _file;

    public override void _Ready()
    {
        _file = GetNode<File>("/root/File");
    }

    public void Look(Vector2 direction)
    {
        var delta = (float)GetProcessDeltaTime();
        var rotation = Rotation;

        if (_file.Settings.CameraInvertY)
        {
            rotation.X += direction.Y * _rotationSpeed * delta;
            rotation.X = Mathf.Clamp(rotation.X, _minXRotation, _maxXRotation);
        }
        else
        {
            rotation.X += direction.Y * _rotationSpeed * delta * -1;
            rotation.X = Mathf.Clamp(rotation.X, _minXRotation, _maxXRotation);
        }

        if (_file.Settings.CameraInvertX)
        {
            rotation.Y += direction.X * _rotationSpeed * delta;
        }
        else
        {
            rotation.Y += direction.X * _rotationSpeed * delta * -1;
        }

        Rotation = rotation;
    }
}
