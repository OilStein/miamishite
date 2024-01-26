using Godot;

public partial class CharacterRotation : Sprite2D
{
    private CharacterMovement characterMovement;

    public override void _Ready()
    {
        characterMovement = GetParent<CharacterMovement>();
    }

    public override void _Process(double delta)
    {
        var moveDir = characterMovement.MoveDirection;
        if (moveDir == Vector2.Zero)
        {
            return;
        }

        var targetAngle = Vector2.Right.AngleTo(moveDir);
        Rotation = Mathf.LerpAngle(Rotation, targetAngle, 1f / 4f);
    }
}
