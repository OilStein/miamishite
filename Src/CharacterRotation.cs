using System;
using Godot;

public partial class CharacterRotation : Node2D
{
    public enum RotationMode
    {
        MoveDirection,
        LookAtTarget
    }

    public RotationMode Mode { get; set; } = RotationMode.MoveDirection;

    public Node2D Target { get; set; }

    private Vector2 moveDir = Vector2.Zero;

    public void MoveDirectionChanged(Vector2 moveDirection)
    {
        moveDir = moveDirection;
    }

    public override void _Process(double delta)
    {
        if (Mode == RotationMode.MoveDirection)
        {
            ProcessMoveDir();
        }
        else if (Mode == RotationMode.LookAtTarget)
        {
            ProcessTarget();
        }
    }

    private void ProcessMoveDir()
    {
        if (moveDir == Vector2.Zero)
        {
            return;
        }

        RotateTowards(moveDir);
    }

    private void ProcessTarget()
    {
        if (Target == null)
        {
            return;
        }

        RotateTowards((Target.GlobalPosition - GlobalPosition).Normalized());
    }

    private void RotateTowards(Vector2 direction)
    {
        var targetAngle = Vector2.Right.AngleTo(moveDir);
        Rotation = Mathf.LerpAngle(Rotation, targetAngle, 1f / 4f);
    }
}
