using Godot;

public partial class CharacterRotation : Node
{
    [Export]
    public CharacterMovement CharacterMovement;
	
    [Export]
    public Node2D Target;

	public override void _Process(double delta)
	{
		var moveDir = CharacterMovement.MoveDirection;
		if (moveDir == Vector2.Zero)
		{
			return;
		}

		var targetAngle = Vector2.Right.AngleTo(moveDir);
		Target.Rotation = Mathf.LerpAngle(Target.Rotation, targetAngle, 1f / 4f);
	}
}
