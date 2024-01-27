using Godot;

public partial class CharacterRotation : Node2D
{
	private Vector2 moveDir = Vector2.Zero;

	public void MoveDirectionChanged(Vector2 moveDirection)
	{
		moveDir = moveDirection;
	}

	public override void _Process(double delta)
	{
		if (moveDir == Vector2.Zero)
		{
			return;
		}

		var targetAngle = Vector2.Right.AngleTo(moveDir);
		Rotation = Mathf.LerpAngle(Rotation, targetAngle, 1f / 4f);
	}
}
