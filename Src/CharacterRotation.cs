using Godot;

public partial class CharacterRotation : Node2D
{
    [Export]
    public CharacterMovement CharacterMovement;

	public override void _Process(double delta)
	{
		var moveDir = CharacterMovement.MoveDirection;
		if (moveDir == Vector2.Zero)
		{
			return;
		}

		var targetAngle = Vector2.Right.AngleTo(moveDir);
		Rotation = Mathf.LerpAngle(Rotation, targetAngle, 1f / 4f);
	}
}
