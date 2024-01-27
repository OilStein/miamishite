using Godot;
using System;

public partial class CharacterMovement : CharacterBody2D
{
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
            if (value != Vector2.Zero)
            {
                moveDirection = value.Normalized();
            }
            else
            {
                moveDirection = value;
            }
        }
    }

    private Vector2 moveDirection = Vector2.Zero;

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
}
