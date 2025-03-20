using Godot;

public partial class Player : Node
{
    [Export]
    private Character _character;

    [Export]
    private SpringArm _springArm;

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
            _character.StartJump();
        }
        else if (@event.IsActionReleased("jump"))
        {
            _character.CompleteJump();
        }
    }

    public override void _Process(double delta)
    {
        _springArm.Look(Input.GetVector("look_left", "look_right", "look_up", "look_down"));
        _inputDirection = Input.GetVector("move_left", "move_right", "move_forward", "move_backward");
        _moveDirection = _springArm.Basis.X * new Vector3(1, 0, 1) * _inputDirection.X;
        _moveDirection += _springArm.Basis.Z * new Vector3(1, 0, 1) * _inputDirection.Y;
        _character.Move(_moveDirection);
    }
}
