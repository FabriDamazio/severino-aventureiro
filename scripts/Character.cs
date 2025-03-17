using Godot;

public partial class Character : CharacterBody3D
{
    public const float JumpVelocity = 4.5f;

    [Export]
    private float _walkingSpeed = 1.0f;

    [Export]
    private float _runningSpeed = 2.0f;

    [Export]
    private float _acceleration = 2.0f;

    [Export]
    private float _deceleration = 4.0f;

    [Export]
    private float _rotationSpeed = Mathf.Pi * 2;

    private Vector3 _xzVelocity = Vector3.Zero;
    private Vector3 _direction;
    private float _angleDifference;
    private float _movementSpeed;

    private AnimationTree _animation;
    private Node3D _rig;

    public override void _Ready()
    {
        _animation = GetNode<AnimationTree>("%AnimationTree");
        _rig = GetNode<Node3D>("%Rig");
        _movementSpeed = _walkingSpeed;
    }

    public void Move(Vector3 direction)
    {
        _direction = direction;
    }

    public void Walk()
    {
        _movementSpeed = _walkingSpeed;
    }

    public void Run()
    {
        _movementSpeed = _runningSpeed;
    }

    public override void _PhysicsProcess(double delta)
    {
        // Rotate the character to the direction.
        // We use:
        // atan2 to get the angle between the direction and the character.
        // MoveToward method to rotate the character to the direction.
        // Clamp method to limit the rotation speed.
        // Sign method to get the direction of the rotation.
        // Wrap method to wrap the angle between -Pi and Pi.
        if (_direction != Vector3.Zero)
        {
            _angleDifference = Mathf.Wrap(
                Mathf.Atan2(_direction.X, _direction.Z) - _rig.Rotation.Y, -Mathf.Pi, Mathf.Pi);

            var rotation = _rig.Rotation;
            rotation.Y +=
              Mathf.Clamp(
                  _rotationSpeed * (float)delta,
                  0,
                  Mathf.Abs(_angleDifference)) * Mathf.Sign(_angleDifference);

            _rig.Rotation = rotation;
        }

        var velocity = Velocity;
        _xzVelocity = new Vector3(Velocity.X, 0, Velocity.Z);

        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }

        // Handle Jump.
        if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }

        if (_direction != Vector3.Zero)
        {
            // Check if the direction is the same as the velocity direction.
            // If it is, move the character toward the direction.
            // If it is not, move the character to the opposite direction.
            if (_direction.Dot(velocity) >= 0)
            {
                _xzVelocity = _xzVelocity.MoveToward(_direction * _movementSpeed, _acceleration * (float)delta);
            }
            else
            {
                _xzVelocity = _xzVelocity.MoveToward(Vector3.Zero, _deceleration * (float)delta);
            }
        }
        else
        {
            _xzVelocity = _xzVelocity.MoveToward(Vector3.Zero, _deceleration * (float)delta);
        }

        // Transform the velocity length into a numner between 0 and 1 dividing by the running speed
        _animation.Set("parameters/Locomotion/blend_position", _xzVelocity.Length() / _runningSpeed);

        Velocity = new Vector3(_xzVelocity.X, velocity.Y, _xzVelocity.Z);
        MoveAndSlide();
    }
}
