using Godot;
using System;

public partial class CharacterMovement : CharacterBody2D
{
    [Signal]
    public delegate void MovementChangedEventHandler(Vector2 moveDirection);

    public delegate void ChangeMoveDirectionCall(Vector2 moveDirection);

    [Export]
    public float Speed { get; set; } = 300.0f;

    public Vector2 MoveDirection
    {
        get
        {
            return moveDirection;
        }
        set
        {
            SetMoveDirection(value);
        }
    }

    private Vector2 moveDirection = Vector2.Zero;

    public override void _Ready()
    {
        HookChildControllers();
    }

    public void SetMoveDirection(Vector2 moveDirection)
    {
        if (moveDirection != Vector2.Zero)
        {
            this.moveDirection = moveDirection.Normalized();
        }
        else
        {
            this.moveDirection = moveDirection;
        }
        EmitSignal(SignalName.MovementChanged, this.moveDirection);
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        if (moveDirection != Vector2.Zero)
        {
            velocity.X = moveDirection.X * Speed;
            velocity.Y = moveDirection.Y * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    private void HookChildControllers()
    {
        foreach (var child in GetChildren())
        {
            if (child is CharacterController)
            {
                ((CharacterController)child).ChangeMoveDirection = SetMoveDirection;
            }
        }
    }
}
