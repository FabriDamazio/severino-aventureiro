using Godot;

public partial class SpringArm : SpringArm3D
{
    [Export]
    private float _rotationSpeed = 1.0f;

    [Export]
    private float _minXRotation = -Mathf.Pi/3;

    [Export]
    private float _maxXRotation = 0f;

    public void Look(Vector2 direction)
    {
        var delta = (float)GetProcessDeltaTime();
        var rotation = Rotation;
        rotation.X = Mathf.Clamp(rotation.X += direction.Y * delta, _minXRotation, _maxXRotation);
        rotation.Y += direction.X * delta;
        Rotation = rotation;
    }
}
