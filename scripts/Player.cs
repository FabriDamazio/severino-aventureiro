using Godot;

public partial class Player : Node
{
    [Export]
    private Character _character;

    [Export]
    private Camera3D _camera;

    private Vector2 _inputDirection;
    private Vector3 _moveDirection;

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("run"))
        {
            _character.Run();
        }
        else if (@event.IsActionReleased("run"))
        {
            _character.Walk();
        }
        else if (@event.IsActionPressed("jump"))
        {
            _character.Jump();
        }
    }

    public override void _Process(double delta)
    {
        _inputDirection = Input.GetVector("move_left", "move_right", "move_forward", "move_backward");
        _moveDirection = _camera.Basis.X * new Vector3(1, 0, 1) * _inputDirection.X;
        _moveDirection += _camera.Basis.Z * new Vector3(1, 0, 1) * _inputDirection.Y;
        _character.Move(_moveDirection);
    }
}
